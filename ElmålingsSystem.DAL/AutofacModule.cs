using Autofac;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Module = Autofac.Module;

namespace ElmålingsSystem.DAL
{
    class AutofacModule : Module
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
