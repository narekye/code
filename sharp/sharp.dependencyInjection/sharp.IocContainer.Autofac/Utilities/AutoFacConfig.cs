using System.Web.Mvc;
using Autofac;
// using Autofac.Integration.WebApi;
using Autofac.Integration.Mvc;
using sharp.IocContainer.Autofac.Controllers;
using sharp.IocContainer.Autofac.Entity;
using sharp.IocContainer.Autofac.Repository;

namespace sharp.IocContainer.Autofac.Utilities
{
    public class AutoFacConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(DefaultController).Assembly);
            builder.RegisterType<CrmRepository>().As<IRepository>().WithParameter("db", new CrmEntities());
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}