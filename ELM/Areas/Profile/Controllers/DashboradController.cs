using Microsoft.AspNetCore.Mvc;

namespace ELM.Areas.Profile.Controllers;

public class DashboradController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}