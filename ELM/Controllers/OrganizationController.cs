using Autofac;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ELM.Controllers;

[Authorize]
public class OrganizationController : Controller
{
    private readonly ILogger<OrganizationController> _logger;
    private readonly ILifetimeScope _scope;

    public OrganizationController(ILogger<OrganizationController> logger, ILifetimeScope scope)
    {
        _logger = logger;
        _scope = scope;
    }
    
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Create()
    {
        return View();
    }
}