using Microsoft.AspNetCore.Identity;

namespace ELM.Users.Entity;

public class Role : IdentityRole<Guid>
{
    public Role()
        : base()
    { 
        
    }

    public Role(string roleName)
        : base(roleName)
    {
        
    }
    
}