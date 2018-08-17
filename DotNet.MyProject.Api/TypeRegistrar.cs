using Autofac;
using Autofac.Integration.WebApi;
using DotNet.Core;
using System.Reflection;
using System.Web.Http;

namespace DotNet.MyProject.Api
{
    public class TypeRegistrar : ITypeRegistrar
    {
        public int Order => 99;

        public void RegisterTypes(ContainerBuilder builder)
        {
            var config = GlobalConfiguration.Configuration;
            var assembly = Assembly.GetExecutingAssembly();

            builder.RegisterApiControllers(assembly);
            builder.RegisterType<ExecutionContext>()
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();

            builder.RegisterModule<JsonConfigModule>();
        }
    }
}