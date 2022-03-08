using Autofac;
using ELM.Users.DbContext;
using ELM.Users.Entity;
using ELM.Users.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ELM.Users;

public class UserModule : Module
{
    private readonly string _connectionString;
    private readonly string _assemblyName;

    public UserModule(string connectionString , string assemblyName)
    {
        _connectionString = connectionString;
        _assemblyName = assemblyName;
    }

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<UserDbContext>().AsSelf()
            .WithParameter("connectionString", _connectionString)
            .WithParameter("assemblyName", _assemblyName)
            .InstancePerLifetimeScope();


        builder.RegisterType<UserDbContext>().As<IUserDbContext>()
            .WithParameter("connectionString", _connectionString)
            .WithParameter("assemblyName", _assemblyName)
            .InstancePerLifetimeScope();
        
        
        /*
        builder.RegisterType<MemberService>().As<IMemberService>()
            .InstancePerLifetimeScope();
        
        builder.RegisterType<MemberService>().AsSelf()
            .InstancePerLifetimeScope();
        
        builder.RegisterType<UserManager<AppUser>>().AsSelf()
            .InstancePerLifetimeScope();
        
        builder.RegisterType<RoleManager<IdentityRole>>().AsSelf()
            .InstancePerLifetimeScope();
            */
       
        
        
        
        base.Load(builder);
    }

}

