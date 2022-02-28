using Autofac;
using ELM.Organization.DbContext;

namespace ELM.Organization;

public class OrganizationModule : Module
{
    private readonly string _connectionString;
    private readonly string _assemblyName;
    
    public OrganizationModule(string connectionString , string assemblyName)
    {
        _connectionString = connectionString;
        _assemblyName = assemblyName;
    }
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<OrganizationDbContext>().AsSelf()
            .WithParameter("connectionString", _connectionString)
            .WithParameter("assemblyName", _assemblyName)
            .InstancePerLifetimeScope();
        
        builder.RegisterType<OrganizationDbContext>().As<IOrganizationDbContext>()
            .WithParameter("connectionString", _connectionString)
            .WithParameter("assemblyName", _assemblyName)
            .InstancePerLifetimeScope();

        // builder.RegisterType<ExpenseRepository>().As<IExpenseRepository>()
        //     .InstancePerLifetimeScope();
        // builder.RegisterType<ExpensesUnitOfWork>().As<IExpensesUnitOfWork>()
        //     .InstancePerLifetimeScope();
        //
        // builder.RegisterType<ExpenseService>().As<IExpenseService>()
        //     .InstancePerLifetimeScope();
        
        base.Load(builder);
    } 
}