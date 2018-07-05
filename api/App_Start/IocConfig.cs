
using Autofac;
using Autofac.Configuration;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using AutoMapper;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

namespace api.App_Start
{
    public class IocConfig
    {
        public static void Configure()
        {
            var buildContainer = new ContainerBuilder();
            //buildContainer.RegisterModule(new ConfigurationSettingsReader("autofac"));

            var asms = System.Web.Compilation.BuildManager.GetReferencedAssemblies
                ().Cast<Assembly>().ToArray();
            buildContainer.RegisterApiControllers(asms);
            buildContainer.RegisterControllers(asms);
            buildContainer.RegisterFilterProvider();

            MapperConfig.Configure(buildContainer);
          

            var container = buildContainer.Build();
            //ServiceLocator.SetContainer(container);
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}