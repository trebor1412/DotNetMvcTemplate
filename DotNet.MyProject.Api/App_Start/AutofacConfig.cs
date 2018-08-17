using Autofac;
using Autofac.Integration.WebApi;
using DotNet.Core;
using System;
using System.Linq;
using System.Reflection;
using System.Web.Compilation;
using System.Web.Http;

namespace DotNet.MyProject.Api
{
    public class AutofacConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;

            var registrars = BuildManager.GetReferencedAssemblies().Cast<Assembly>()
                                         .SelectMany(p => p.ExportedTypes.Where(s => s.IsAssignableTo<ITypeRegistrar>() && s.IsInterface == false))
                                         .Select(p => (ITypeRegistrar)Activator.CreateInstance(p))
                                         .OrderBy(p => p.Order)
                                         .ToList();

            registrars.ForEach(x => x.RegisterTypes(builder));
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);            
        }
    }
}