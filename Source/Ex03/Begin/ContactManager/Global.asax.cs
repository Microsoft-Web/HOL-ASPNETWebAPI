using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.ComponentModel.Composition.Lightweight.Hosting;
using System.ComponentModel.Composition.Registration;
using System.ComponentModel.Composition.Web.Mvc;
using ContactManager.Parts;
using ContactManager.Models;

namespace ContactManager
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var conventions = new RegistrationBuilder();
            conventions.ForTypesDerivedFrom<IController>().Export();
            conventions.ForTypesDerivedFrom<ApiController>().Export();

            conventions
               .ForTypesMatching((t) =>
                   t.Namespace != null &&
                       (t.Namespace.Contains(".Parts.") ||
                           t.Namespace.EndsWith("Parts")))
                   .Export()
                   .ExportInterfaces();

            CompositionProvider.SetConfiguration(
                new ContainerConfiguration()
                   .WithAssembly(typeof(WebApiApplication).Assembly, conventions)
                );

            GlobalConfiguration.Configuration.DependencyResolver = new DependencyResolverAdapter(DependencyResolver.Current);
        }

        private class DependencyResolverAdapter : System.Web.Http.Dependencies.IDependencyResolver
        {
            private System.Web.Mvc.IDependencyResolver _innerDependencyResolver;

            public DependencyResolverAdapter(System.Web.Mvc.IDependencyResolver dependendyResolver)
            {
                this._innerDependencyResolver = dependendyResolver;
            }

            public System.Web.Http.Dependencies.IDependencyScope BeginScope()
            {
                return this;
            }

            public object GetService(Type serviceType)
            {
                return this._innerDependencyResolver.GetService(serviceType);
            }

            public IEnumerable<object> GetServices(Type serviceType)
            {
                return this._innerDependencyResolver.GetServices(serviceType);
            }

            public void Dispose()
            {
                // It is not need to disposed the innerDependencyResolver because we didn't create it
            }
        }
    }
}
