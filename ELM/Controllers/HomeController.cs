using System.Diagnostics;
using Autofac;
using ELM.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using ELM.Models;
using ELM.Users.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace ELM.Controllers;

[AllowAnonymous]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ILifetimeScope _scope;
    private readonly UserManager<AppUser> _userManager;
   

    public HomeController(ILogger<HomeController> logger, ILifetimeScope scope, UserManager<AppUser> userManager)
    {
        _logger = logger;
        _scope = scope;
        _userManager = userManager;


    }
    
[AllowAnonymous]
    public IActionResult Index()
    {
     var model = _scope.Resolve<RecentOrgModel>();
         model.GetOrgByOwner(_userManager.GetUserId(HttpContext.User));
        return View(model);
    }
    
    
[AllowAnonymous]
    public IActionResult Privacy()
    {
        return View();
    }
    
   
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}