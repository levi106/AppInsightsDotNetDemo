using Autofac;
using Autofac.Integration.Mvc;
using FrontApp1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace FrontApp1
{
    public static class AutofacConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterSource(new ViewRegistrationSource());
            builder.RegisterInstance(new ExceptionService())
                   .As<IExceptionService>();
            builder.RegisterInstance(new PerformanceService())
                   .As<IPerformanceService>();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
        }
    }
}