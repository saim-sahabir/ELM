using Microsoft.AspNetCore.Identity;

namespace ELM.Users.BusinessObjects;

public class UserRegister : IdentityUser
{
    public string? DisplayName { get; set; }
    public string? Password { get; set; }
    
}