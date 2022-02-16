using Autofac;
using ELM.Areas.Profile.Models;
using Microsoft.AspNetCore.Mvc;

namespace ELM.Areas.Profile.Controllers;

[Area("Profile")]

public class AccountController : Controller
{ 
    private readonly ILogger<AccountController> _logger;
    private readonly ILifetimeScope _Scope;

    public AccountController(ILogger<AccountController> logger , ILifetimeScope lifetimeScope)
    {
        _logger = logger; 
        _Scope = lifetimeScope;
    }
    // GET
    public IActionResult Login()
    {
        _logger.LogInformation("login area");
        
        return View();
    }

    
    [HttpGet]
    public IActionResult Register()
    {
        var registerModel  =  _Scope.Resolve<RegisterModel>();
        
        return View(registerModel);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Register(RegisterModel registerModel)
    {
        return Content("hello");
    }

    public IActionResult ForgetPassword()
    {
        return View();
    }
}