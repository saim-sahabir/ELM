using Autofac;
using ELM.Areas.Identity.Data;
using ELM.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ELM.Controllers;

[Authorize]
public class OrganizationController : Controller
{
    private readonly ILogger<OrganizationController> _logger;
    private readonly ILifetimeScope _scope;
    private readonly UserManager<WebUser> _userManager;
    private readonly IWebHostEnvironment _hostingEnvironment;

    public OrganizationController(IWebHostEnvironment hostEnvironment, ILogger<OrganizationController> logger, ILifetimeScope scope, UserManager<WebUser> userManager)
    {
        _logger = logger;
        _scope = scope;
        _userManager = userManager;
        _hostingEnvironment = hostEnvironment;
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
            model.Resolve(_scope);
            try
            {                
                model.OwnerId = _userManager.GetUserId(HttpContext.User); 
                model.CreateOrganizaton();
                
                    return RedirectToAction("Step2",  new { Id = model.Id });
                
                
            }
            
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                TempData["ResponseMessage"] = "There was a problem in creating Organization.";
                TempData["ResponseType"] = ResponseTypes.Danger;              
            }
         
          
        }
        return View();
    }

    [HttpGet]
    public IActionResult Step2(int Id)
    {
        try
        {
            var model = _scope.Resolve<OrganizationSetupModel>();
            model.Resolve(_scope);
            model.Id = Id;
            model.OwnerId = _userManager.GetUserId(HttpContext.User); 
            
          if (Id != 0 && model.OwnerId == _userManager.GetUserId(HttpContext.User))
          { 
              model.OrganizationLoadData();
              return View(model);
             
          } 
          return RedirectToAction("Index");
        }
        catch (Exception ex)
        { 
            _logger.LogError(ex, ex.Message);

            TempData["ResponseMessage"] = "There was a problem in Organization setup.";
            TempData["ResponseType"] = ResponseTypes.Danger;       
            return RedirectToAction("Create");
           
        }
        
       
    }

    [HttpPost]
    public IActionResult UploadLogo()
    {
        string base64 = Request.Form["image"];
        string LogoId = Request.Form["LogoId"];
        byte[] bytes = Convert.FromBase64String(base64.Split(',')[1]);
        var time = DateTime.Now.ToString("yyyyMMddHHmmss");
        string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload", $"{time}logo.png");
        var fileName = $"{time}logo.png";
        using (FileStream stream = new FileStream(filePath, FileMode.Create))
        {
            stream.Write(bytes, 0, bytes.Length);
            stream.Flush();
        }

        var model = _scope.Resolve<OrganizationSetupModel>();
        model.Id = int.Parse(LogoId);
        model.Logo = fileName;
        model.LogoSetup();
        return Json(new { success = true, filePath = $"{time}logo.png", msg = "Logo setup successfully." });
        
    }
    
}