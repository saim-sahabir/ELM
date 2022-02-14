using Autofac;
using ELM.Expenses.DbContext;
using ELM.Expenses.Repositories;
using ELM.Expenses.Services;
using ELM.Expenses.UnitOfWorks;
using EML.DataAccess;

namespace ELM.Expenses;

public class ExpenseModule : Module 

{
    private readonly string _connectionString;
    private readonly string _assemblyName;
    
    public ExpenseModule(string connectionString , string assemblyName)
    {
        _connectionString = connectionString;
        _assemblyName = assemblyName;
    }

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ElmDbContext>().AsSelf()
            .WithParameter("connectionString", _connectionString)
            .WithParameter("assemblyName", _assemblyName)
            .InstancePerLifetimeScope();
        
        builder.RegisterType<ElmDbContext>().As<IElmDbContext>()
            .WithParameter("connectionString", _connectionString)
            .WithParameter("assemblyName", _assemblyName)
            .InstancePerLifetimeScope();

        builder.RegisterType<ExpenseRepository>().As<IExpenseRepository>()
            .InstancePerLifetimeScope();
        builder.RegisterType<ExpensesUnitOfWork>().As<IExpensesUnitOfWork>()
            .InstancePerLifetimeScope();
        
         builder.RegisterType<ExpenseService>().As<IExpenseService>()
             .InstancePerLifetimeScope();
        
        base.Load(builder);
    } 
}