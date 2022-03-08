using ELM.Users.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ELM.Users.DbContext;

public class UserDbContext :  IdentityDbContext<AppUser, Role, Guid, UserClaim, UserRole, UserLogin ,RoleClaim ,UserToken>, IUserDbContext
                              
{
    
    private readonly string _connectionString;
    private readonly string _assemblyName;

    public UserDbContext(DbContextOptions<UserDbContext> options) 
        : base(options)
    {
        
    }
        
        
        
    
    public UserDbContext(string connectionString, string assemblyName)
           
        {
            _connectionString = connectionString;
            _assemblyName = assemblyName;
            
        }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured) 
            optionsBuilder.UseSqlServer(_connectionString, m => m.MigrationsAssembly(_assemblyName));
        base.OnConfiguring(optionsBuilder);
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {

        base.OnModelCreating(builder);
    }
    
   

}