using Module = Autofac.Module;
using System.Reflection;
using Autofac;

namespace ElmålingsSystem.MVC
{
    public class AutofacModule : Module  //module for user-defined modules
    {
        protected override void Load(ContainerBuilder builder)
        {
            var asm = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(asm)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
