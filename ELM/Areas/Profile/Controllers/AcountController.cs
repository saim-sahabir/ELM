using Autofac;
using Microsoft.AspNetCore.Mvc;

namespace ELM.Areas.Profile.Controllers;

[Area("Profile")]

public class AcountController : Controller
{ 
    private readonly ILogger<AcountController> _logger;
    private readonly ILifetimeScope _Scope;

    public AcountController(ILogger<AcountController> logger , ILifetimeScope lifetimeScope)
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

    public IActionResult Register()
    {
        return View();
    }

    public IActionResult ForgetPassword()
    {
        return View();
    }
}