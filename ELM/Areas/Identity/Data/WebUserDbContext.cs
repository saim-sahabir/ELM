using ELM.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ELM.Areas.Identity.Data;

public class WebUserDbContext : IdentityDbContext<WebUser>, IWebUserDbContext

{

    private readonly string _connectionString;
    private readonly string _assemblyName;


    public WebUserDbContext(string connectionString, string assemblyName)

    {
        _connectionString = connectionString;
        _assemblyName = assemblyName;

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer(_connectionString, m => m.MigrationsAssembly(_assemblyName));
        base.OnConfiguring(optionsBuilder);

    }

    public IdentityDbContext<WebUser> AspNetUsers { get; set; }

}

