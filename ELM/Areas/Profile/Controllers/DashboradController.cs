using Microsoft.AspNetCore.Mvc;

namespace ELM.Areas.Profile.Controllers;
 [Area("Profile")]
public class DashboradController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}