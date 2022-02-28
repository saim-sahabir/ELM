using Autofac;
using ELM.Models;
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
    
    [HttpGet]
    public IActionResult Create()
    {
        var model = _scope.Resolve<OrganizationModel>();
        return View(model);
    }
    
    [ HttpPost, ValidateAntiForgeryToken]
    public IActionResult Create(OrganizationModel model)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction("Step2");
        }
        return View();
    }

    [HttpGet]
    public IActionResult Step2()
    {
        return View();
    }

}