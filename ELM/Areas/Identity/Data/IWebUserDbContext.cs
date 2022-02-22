using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ELM.Areas.Identity.Data;

public interface IWebUserDbContext
{
    public IdentityDbContext<WebUser> AspNetUsers { get; set; }
}