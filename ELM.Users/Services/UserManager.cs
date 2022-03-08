using ELM.Users.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ELM.Users.Services;

public class UserManager : UserManager<AppUser>
{
    public UserManager(IUserStore<AppUser> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<AppUser> passwordHasher, IEnumerable<IUserValidator<AppUser>> userValidators, IEnumerable<IPasswordValidator<AppUser>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider serviceProvider, ILogger<UserManager<AppUser>> logger) 
        : base(store , optionsAccessor, passwordHasher , userValidators , passwordValidators, keyNormalizer, errors, serviceProvider, logger)
    {
        
    }
}