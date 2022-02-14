
using Autofac;
using ELM.Models;

namespace ELM;

public class WebModule :Module
{
    protected override void Load(ContainerBuilder builder)
    {
        //builder.RegisterType<TestClass>().As<ITestClass>()
            //.InstancePerLifetimeScope();
        builder.RegisterType<ExpenseModel>().AsSelf();
        base.Load(builder);
    }
}

