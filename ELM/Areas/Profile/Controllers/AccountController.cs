using Autofac;
using ELM.Areas.Profile.Models;
using Microsoft.AspNetCore.Mvc;

namespace ELM.Areas.Profile.Controllers;

[Area("Profile")]

public class AccountController : Controller
{ 
    private readonly ILogger<AccountController> _logger;
    private readonly ILifetimeScope _scope;

    public AccountController(ILogger<AccountController> logger , ILifetimeScope lifetimeScope)
    {
        _logger = logger; 
        _scope = lifetimeScope;
    }
    // GET
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
    public IActionResult Register(RegisterModel model)
    {
        if (ModelState.IsValid)
        { 
            model.Resolve(_scope);
            
             model.RegisterUser();
        }

        return View(model);
    }

    public IActionResult ForgetPassword()
    {
        return View();
    }
}