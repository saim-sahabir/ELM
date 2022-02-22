using ELM.Users.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ELM.Users.DbContext;

public class UserDbContext :  IdentityDbContext<AppUser>, IUserDbContext
                              
{
    
    private readonly string _connectionString;
    private readonly string _assemblyName;
    
    
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
     
    public IdentityDbContext<AppUser> AspNetUsers { get; set; } 

}