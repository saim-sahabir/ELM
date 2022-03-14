using System.Net;
using Autofac;
using ELM.Models;
using ELM.Users.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ELM.Controllers;

public class ExpenseController : Controller
{
    private readonly ILogger<ExpenseController> _logger;
    private readonly ILifetimeScope _scope;
    private readonly UserManager<AppUser> _userManager;

    public ExpenseController(ILogger<ExpenseController> logger, ILifetimeScope scope, UserManager<AppUser> userManager)
    {
        _logger = logger;
        _scope = scope;
        _userManager = userManager;
    }
    // GET
    public  IActionResult Index()
    {
        return View();
    }
    
    [HttpPost , ValidateAntiForgeryToken]
    public IActionResult Create(ExpenseModel model)
    {
        try
        {
            var items = JsonConvert.DeserializeObject<List<ExpenseItemModel>>(model.ItemsList); 
            model.ExpenseItem = items;
            model.OwnerId = _userManager.GetUserId(HttpContext.User);
            if (ModelState.IsValid)
            {
                model.Resolve(_scope);
                model.AddExpense();
                 
                return Json(new { id = model.LastId, msg="ok" });
                // return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            
            return StatusCode(500);
        }
    }

    public IActionResult ExpensePrint(string id)
    {
        if (id == "")
        {
            return StatusCode(404);
        }

        try
        {
            var model = _scope.Resolve<ExpensesViewModel>();
            model.Resolve(_scope);
            model.Id = int.Parse(id);
            model.LoadData();
            // model.ExpensePerson = _userManager.FindByIdAsync(model.OwnerId).Result.DisplayName;
            // model.ExpensePersonEmail = _userManager.FindByIdAsync(model.OwnerId).Result.Email;
            return  PartialView("_ExpencesTemplate", model);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            
            return StatusCode(500);
        }
       
    }
}