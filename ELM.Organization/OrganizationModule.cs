using Autofac;
using ELM.Organization.DbContext;
using ELM.Organization.Repositories;
using ELM.Organization.Services;
using ELM.Organization.UnitOfWorks;

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

         builder.RegisterType<OrganizationRepository>().As<IOrganizationRepository>()
             .InstancePerLifetimeScope();
         builder.RegisterType<OrganizationUnitOfWork>().As<IOrganizationUnitOfWork>()
             .InstancePerLifetimeScope();
        
         builder.RegisterType<OrganizationService>().As<IOrganizationServices>()
            .InstancePerLifetimeScope();
        
        base.Load(builder);
    } 
}