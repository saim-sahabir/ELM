using Autofac;
using Microsoft.AspNetCore.Mvc;

namespace ELM.Controllers;

public class ExpenseController : Controller
{
    private readonly ILogger<ExpenseController> _logger;
    private readonly ILifetimeScope _scope;

    public ExpenseController(ILogger<ExpenseController> logger, ILifetimeScope scope)
    {
        _logger = logger;
        _scope = scope;
    }
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Create()
    {
        return View();
    }
}