using Autofac;
using Microsoft.AspNetCore.Mvc;

namespace ELM.Controllers;

public class DepositController : Controller
{
    private readonly ILogger<DepositController> _logger;
    private readonly ILifetimeScope _scope;

    public DepositController(ILogger<DepositController> logger, ILifetimeScope scope)
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

