using ELM.Users.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ELM.Users.DbContext;

public interface IUserDbContext
{
    public IdentityDbContext<AppUser> AspNetUsers { get; set; }
}