using System.Diagnostics;
using Autofac;
using Microsoft.AspNetCore.Mvc;
using ELM.Models;

namespace ELM.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ILifetimeScope _scope;

    public HomeController(ILogger<HomeController> logger, ILifetimeScope scope)
    {
        _logger = logger;
        _scope = scope;

    }

    public IActionResult Index()
    {
        
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    
     public IActionResult Add()
     {
         var model = _scope.Resolve<ExpenseModel>();
        model.CreateExpense("bill" , 2000);
        return Content("Add Succeuss");
     }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}