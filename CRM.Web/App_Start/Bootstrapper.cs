using Autofac;
using Autofac.Integration.Mvc;
using CRM.Data.Infrastructure;
using CRM.Data.Repositories;
using CRM.Service;
using CRM.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace CRM.Web
{
    public static class Bootstrapper
    {
        public static void Run()
        {
            SetAutofacContainer();
            //Configure AutoMapper
            //AutoMapperConfiguration.Configure();
        }

        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            // Repositories
            //builder.RegisterAssemblyTypes(typeof(ChannelTypeRepository).Assembly)
            //    .Where(t => t.Name.EndsWith("Repository"))
            //    .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(CustomerRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterGeneric(typeof(CRMService<>)).As(typeof(ICRMService<>)).InstancePerDependency();
            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
       .AsClosedTypesOf(typeof(IRepository<>)).AsImplementedInterfaces();
            // Services
            builder.RegisterAssemblyTypes(typeof(CustomerService).Assembly)
                    .Where(t => t.Name.EndsWith("Service"))
                    .AsImplementedInterfaces().InstancePerRequest();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}