using Autofac;
using ELM.Users.BusinessObjects;
using ELM.Users.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;

namespace ELM.Users.Services;

public class MemberService : IMemberService 
{
    private readonly ILifetimeScope _scope;
    private readonly UserManager<AppUser> _userManager;
    private readonly ILogger<MemberService> _logger;
    private readonly IEmailSender _emailSender;

   
   
    public MemberService(ILogger<MemberService> logger, ILifetimeScope scope, UserManager<AppUser> userManager ,IEmailSender emailSender
                                                                             )
    {
        _logger = logger;
        _emailSender = emailSender;
        _scope = scope;
        _userManager = userManager;
       
    
    }

    public async Task CreateUser(UserRegister userRegister)
    {
        var appUser = new AppUser()
        {
            DisplayName = userRegister.DisplayName,
            Email = userRegister.Email,
            UserName = userRegister.Email
            
        };
        var result = await _userManager.CreateAsync(appUser, userRegister.Password);

        if (result.Succeeded)
        {
            _logger.LogInformation("user create with password");
        }
    }
    
}