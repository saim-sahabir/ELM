using Microsoft.AspNetCore.Identity;

namespace ELM.Users.Entity;

public class AppUser : IdentityUser<Guid>
{
    
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Address { get; set; }
    public string? DisplayName { get; set; }
    public string? ProfileImage { get; set; }
    public string? TwitterUserId { get; set; }
    public string? TwitterScreenName { get; set; }

    public string? FacebookUserId { get; set; }

    public string? GoogleUserId { get; set; }

    public string? GoogleProfilePageUrl { get; set; }

}