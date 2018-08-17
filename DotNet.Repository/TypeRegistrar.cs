using Autofac;
using DotNet.Core;
using System.Reflection;

namespace DotNet.Repository
{
    public class TypeRegistrar : ITypeRegistrar
    {
        public int Order => 10;

        public void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                   .AsImplementedInterfaces()
                   .InstancePerRequest();
        }
    }
}