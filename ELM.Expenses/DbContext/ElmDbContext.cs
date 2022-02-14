using ELM.Expenses.Entities;
using Microsoft.EntityFrameworkCore;
namespace ELM.Expenses.DbContext;


public class ElmDbContext : Microsoft.EntityFrameworkCore.DbContext, IElmDbContext 
{
    private readonly string _connectionString;
    private readonly string _assemblyName;

    public ElmDbContext(string connectionString, string assemblyName)
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
    
    public DbSet<Expense> Expenses { get; set; }
    public DbSet<ExpenseItem> ExpenseItems { get; set; }
} 