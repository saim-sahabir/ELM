using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ELM.Areas.Profile.Controllers;
 [Area("Profile")]
 [Authorize]
public class DashboradController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}