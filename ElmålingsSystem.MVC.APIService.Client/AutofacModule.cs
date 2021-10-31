using Autofac;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ElmålingsSystem.MVC.APIService.Client
{
    public class AutofacModule : Autofac.Module  //module for user-defined modules
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
