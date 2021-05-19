using Autofac;
using Autofac.Integration.Mvc;
using FrontAppNoAI1.Services;
using System.Reflection;
using System.Web.Mvc;

namespace FrontAppNoAI1.App_Start
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
            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
        }
    }
}