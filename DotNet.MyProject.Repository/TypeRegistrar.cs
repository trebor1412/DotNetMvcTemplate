using Autofac;
using DotNet.Core;
using System.Reflection;

namespace DotNet.MyProject.Repository
{
    public class TypeRegistrar : ITypeRegistrar
    {
        public int Order => 30;

        public void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();
        }
    }
}