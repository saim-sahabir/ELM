using Microsoft.EntityFrameworkCore;

namespace ELM.Organization.DbContext;

public class OrganizationDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    private readonly string _connectionString;
    private readonly string _assemblyName;

    public OrganizationDbContext(string connectionString, string assemblyName)
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
    
   
} 
