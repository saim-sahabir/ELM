using ELM.Organization.Entities;
using Microsoft.EntityFrameworkCore;

namespace ELM.Organization.DbContext;

public class OrganizationDbContext : Microsoft.EntityFrameworkCore.DbContext, IOrganizationDbContext
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

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Expenses>()
            .HasMany(e => e.ItemsList)
            .WithOne(i => i.Expenses);
        
        // builder.Entity<Organizations>()
        //     .HasMany(o => o.ExpensesList)
        //     .WithOne(i => i.Organizations);
        //
        // builder.Entity<Organizations>()
        //     .HasMany(e => e.Deposits)
        //     .WithOne(i => i.Organizations);
        // builder.Entity<Organizations>()
        //     .HasMany(m => m.MembersList )
        //     .WithOne(i => i.Organizations);
    }

    public DbSet<Organizations> Organizations { get; set; }
    public DbSet<OrgMembers> OrgMembers { get; set; }
    public DbSet<Expenses> Expenses { get; set; }
    public DbSet<ExpenseItems> ExpenseItems { get; set; }
    public DbSet<Deposit> Deposits { get; set; }
    public DbSet<Notification> Notifications { get; set; }

} 
