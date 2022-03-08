using ELM.Users.Entity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ELM.Users.Services;

public class SignInManager : SignInManager<AppUser>
{
    public SignInManager(UserManager<AppUser> userManager,
        IHttpContextAccessor contextAccessor,
        IUserClaimsPrincipalFactory<AppUser> claimsPrincipalFactory,
        IOptions<IdentityOptions> optionsAccessor,
        ILogger<SignInManager<AppUser>> logger,
        IAuthenticationSchemeProvider schemes,
        IUserConfirmation<AppUser> userConfirmation): base(userManager, contextAccessor,claimsPrincipalFactory,optionsAccessor,logger,schemes, userConfirmation)
    {
        
    }
}