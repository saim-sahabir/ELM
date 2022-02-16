
using Autofac;
using ELM.Areas.Profile.Models;
using ELM.Models;

namespace ELM;

public class WebModule :Module
{
    protected override void Load(ContainerBuilder builder)
    {
        //builder.RegisterType<TestClass>().As<ITestClass>()
            //.InstancePerLifetimeScope();
        builder.RegisterType<ExpenseModel>().AsSelf();
        builder.RegisterType<RegisterModel>().AsSelf();
        base.Load(builder);
    }
}

