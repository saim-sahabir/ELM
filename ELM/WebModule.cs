
using Autofac;
using ELM.Areas.Identity.Data;
using ELM.Areas.Profile.Models;
using ELM.Models;
using ELM.Users.Entity;
using Microsoft.AspNetCore.Identity;

namespace ELM;

public class WebModule :Module
{
    
    // private readonly string _connectionString;
    // private readonly string _assemblyName;
    //
    // public WebModule(string connectionString , string assemblyName)
    // {
    //     _connectionString = connectionString;
    //     _assemblyName = assemblyName;
    // }
    
    protected override void Load(ContainerBuilder builder)
    {
        //builder.RegisterType<TestClass>().As<ITestClass>()
            //.InstancePerLifetimeScope();
        builder.RegisterType<ExpenseModel>().AsSelf();
         builder.RegisterType<RegisterModel>().AsSelf();
         builder.RegisterType<LoginModel>().AsSelf();
         builder.RegisterType<ProfileEditModel>().AsSelf();
         builder.RegisterType<RecentOrgModel>().AsSelf();
         builder.RegisterType<MemberModel>().AsSelf();
         builder.RegisterType<ExpenseItemModel>().AsSelf();
         builder.RegisterType<ExpensesViewModel>().AsSelf();
         
         // builder.RegisterType<WebUserDbContext>().AsSelf()
         //            .WithParameter("connectionString", _connectionString)
         //            .WithParameter("assemblyName", _assemblyName)
         //            .InstancePerLifetimeScope();
         //
         // builder.RegisterType<WebUserDbContext>().As<IWebUserDbContext>()
         //     .WithParameter("connectionString", _connectionString)
         //     .WithParameter("assemblyName", _assemblyName)
         //     .InstancePerLifetimeScope();
         
         builder.RegisterType<OrganizationModel>().AsSelf();
         builder.RegisterType<OrganizationSetupModel>().AsSelf();
         
        base.Load(builder);
    }
}

