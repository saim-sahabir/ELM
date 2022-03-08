using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using ELM;
using ELM.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ELM.Data;
using ELM.Expenses;
using ELM.Expenses.DbContext;
using ELM.Organization;
using ELM.Organization.DbContext;
using ELM.Users;
using ELM.Users.DbContext;
using ELM.Users.Entity;
using ELM.Users.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var assemblyName = Assembly.GetExecutingAssembly().FullName;

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{  
    containerBuilder.RegisterModule(new WebModule());
    containerBuilder.RegisterModule(new OrganizationModule(connectionString, assemblyName));
    containerBuilder.RegisterModule(new UserModule(connectionString, assemblyName));
    
  
});
// Add services to the container.
builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseSqlServer(connectionString, m => m.MigrationsAssembly(assemblyName)));
builder.Services.AddDbContext<OrganizationDbContext>(options =>
    options.UseSqlServer(connectionString, m => m.MigrationsAssembly(assemblyName)));


builder.Services.AddDatabaseDeveloperPageExceptionFilter();


builder.Services.AddIdentity<AppUser, Role>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddUserManager<UserManager>()
    .AddRoleManager<RoleManager>()
    .AddSignInManager<SignInManager>()
    .AddEntityFrameworkStores<UserDbContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();




builder.Services.Configure<IdentityOptions>(options =>
{
   
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
    
    // Default Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;
    
    // Default User settings.
    options.User.AllowedUserNameCharacters =  "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+/";
    options.User.RequireUniqueEmail = true; 
    
});


builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.Cookie.Name = "app-uc";
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    options.LoginPath = "/Profile/Account/Login";
    // ReturnUrlParameter requires 
    //using Microsoft.AspNetCore.Authentication.Cookies;
    options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
    options.SlidingExpiration = true;
});

    builder.Services.AddSession(options =>
    {
        options.IdleTimeout = TimeSpan.FromMinutes(30);
        options.Cookie.HttpOnly = true;
        options.Cookie.IsEssential = true;
    }
);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("InternalUser", policy => policy.RequireRole("Admin"));
});

builder.Services.AddControllersWithViews();

//serilog Config 


builder.Host.UseSerilog((ctx, lc) => lc
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .ReadFrom.Configuration(builder.Configuration));

try {
    
    var app = builder.Build();
    Log.Information("Application Starting Up");
// Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseMigrationsEndPoint();
    }
    else
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();
    app.UseCookiePolicy();
//area Route Config 

    app.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

// main Route 
    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    app.MapRazorPages();
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application start-up filed");
}
finally
{
    Log.CloseAndFlush();
}
