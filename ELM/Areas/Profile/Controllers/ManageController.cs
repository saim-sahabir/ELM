using Autofac;
using ELM.Areas.Profile.Models;
using ELM.Models;
using ELM.Users.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ELM.Areas.Profile.Controllers;

[Area("Profile")]
[Authorize]
public class ManageController : Controller
{
    
    private readonly ILogger<ManageController> _logger;
    private readonly ILifetimeScope _scope;
    private readonly UserManager<AppUser> _userManager;
    private readonly IWebHostEnvironment _hostingEnvironment;
    private readonly SignInManager<AppUser> _signInManager;

    public ManageController(IWebHostEnvironment hostEnvironment, ILogger<ManageController> logger,
        ILifetimeScope scope,
        UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager)
    {
        _logger = logger;
        _scope = scope;
        _userManager = userManager;
        _hostingEnvironment = hostEnvironment;
        _signInManager = signInManager;
    }
    
    // GET
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var model = _scope.Resolve<ProfileEditModel>();
        
        var userData =  await _userManager.GetUserAsync(User);
        model.Id = userData.Id;
        model.Address = userData.Address;
        model.Email = userData.Email;
        model.FirstName = userData.FirstName;
        model.LastName = userData.LastName;
        model.PhoneNumber = userData.PhoneNumber;
        model.ProfileImage = userData.ProfileImage;
        model.UserName = userData.UserName;
        model.DisplayName = userData.DisplayName;
        return View(model);
    }
 
    
    
    
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(ProfileEditModel model)
    { 
        var userData = await _userManager.GetUserAsync(User);
        if (ModelState.IsValid)
        {
           try 
           {

                     userData.FirstName = model.FirstName;
                     userData.LastName = model.LastName;
                     userData.Address = model.Address;
                     userData.DisplayName = model.DisplayName;
                     userData.PhoneNumber = model.PhoneNumber;
                     IdentityResult  result = await _userManager.UpdateAsync(userData);
                    if (result.Succeeded)
                    {
                        await _signInManager.RefreshSignInAsync(userData);
                        TempData["ResponseMessage"] = "Successfully Updated Profile.";
                        TempData["ResponseType"] = ResponseTypes.Success;
                        return RedirectToAction("Index");
                    }
                     
           

           }
           catch (Exception ex)
           {
            _logger.LogError(ex, ex.Message);

            TempData["ResponseMessage"] = "There was a problem in updating Profile.";
            TempData["ResponseType"] = ResponseTypes.Danger;
            return View(model);
           } 
        }
        
        return View(model);
    }
    
    
    [HttpPost]
    public async Task<IActionResult> UploadProfile()
    {
        string base64 = Request.Form["image"];
        byte[] bytes = Convert.FromBase64String(base64.Split(',')[1]);
        var time = DateTime.Now.ToString("yyyyMMddHHmmss");
        string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload", $"{time}profile.png");
        var fileName = $"{time}profile.png";
        using (FileStream stream = new FileStream(filePath, FileMode.Create))
        {
            stream.Write(bytes, 0, bytes.Length);
            stream.Flush();
        }
        
        var userImage = await _userManager.GetUserAsync(User);
        userImage.ProfileImage = fileName;
        IdentityResult  result = await _userManager.UpdateAsync(userImage);
        if (result.Succeeded)
        {
            await _signInManager.RefreshSignInAsync(userImage);
            return Json(new { success = true, filePath = $"{time}profile.png", msg = "Image Update successfully." });
        }
        else
        {
             return Json(new { success = true, filePath = $"{time}profile.png", msg = "Image Update Problem." });
        }
        
        
    }

}