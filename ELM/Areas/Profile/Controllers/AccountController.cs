using System.Text;
using System.Text.Encodings.Web;
using Autofac;
using ELM.Areas.Profile.Models;
using ELM.Users.Entity;
using ELM.Users.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

namespace ELM.Areas.Profile.Controllers;

[Area("Profile")]

public class AccountController : Controller
{ 
    private readonly ILogger<AccountController> _logger;
    private readonly ILifetimeScope _scope;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly UserManager<AppUser> _userManager;
    private readonly IEmailSender _emailSender;

    public AccountController(ILogger<AccountController> logger ,
        ILifetimeScope lifetimeScope,
        SignInManager<AppUser> signInManager,
        UserManager<AppUser> userManager,
        IUserStore<AppUser> userStore,
        IEmailSender emailSender)
    {
        _logger = logger; 
        _scope = lifetimeScope;
        _signInManager = signInManager;
        _userManager = userManager;
        _emailSender = emailSender;
    }
    
    // GET
    [HttpGet] 
    public async Task<IActionResult> Login(string returnUrl = null)
    {
         var model = _scope.Resolve<LoginModel>();
            
            if (!string.IsNullOrEmpty(model.ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, model.ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

                model.ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

                model.ReturnUrl = returnUrl;
                
                return View();
    }

     [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            model.ReturnUrl ??= Url.Content("~/");

                model.ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    return LocalRedirect(model.ReturnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }
            
            return View(model);
        }
        
        [HttpGet]
       public async Task<IActionResult> Register(string returnUrl = null)
       {
           var model = _scope.Resolve<RegisterModel>();
               model.ReturnUrl = returnUrl;
               model.ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
               return View();
       }

       [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            model.ReturnUrl ??= Url.Content("~/");
                model.ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList(); 
            if (ModelState.IsValid) 
            {
                var user = new AppUser();
                
                user.DisplayName = model.DisplayName;
                user.UserName = model.DisplayName;
                user.Email = model.Email;
                var result = await _userManager.CreateAsync(user, model.Password);

                 if (result.Succeeded)
                 {
                    _logger.LogInformation("User created a new account with password.");

                    var userId = await _userManager.GetUserIdAsync(user);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = userId, code = code, returnUrl = model.ReturnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(model.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = model.Email, returnUrl = model.ReturnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(model.ReturnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
  
     
        
 /*   // GET
    [HttpGet]
    public IActionResult Login()
    {

      var model  = _scope.Resolve<LoginModel>();
        return View(model);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Login(LoginModel loginModel)
    {
        if (ModelState.IsValid)
        {
            return View(loginModel);
        }
        return View(loginModel);
    }
    
    [HttpGet]
    public IActionResult Register()
    {
        var registerModel = _scope.Resolve<RegisterModel>();
        
        return View(registerModel);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterModel model)
    {
        if (ModelState.IsValid)
        { 
            model.Resolve(_scope);
            
         await  model.CreateUser();
        }

        return View(model);
    }

   
    */ 
       public  IActionResult ForgetPassword()
          {
              return View();
          }
 
 
 
}