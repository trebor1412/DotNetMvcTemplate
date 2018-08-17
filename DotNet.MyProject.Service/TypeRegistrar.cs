using Autofac;
using AutoMapper;
using DotNet.Core;
using DotNet.Service;
using System.Linq;
using System.Reflection;

namespace DotNet.MyProject.Service
{
    public class TypeRegistrar : ITypeRegistrar
    {
        public int Order => 40;

        public void RegisterTypes(ContainerBuilder builder)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var services = assembly.GetExportedTypes()
                                   .Where(x => x.FullName.EndsWith("Service") && x.IsInterface == false)
                                   .ToList();

            services.ForEach(x =>
            {
                builder.RegisterType(x)
                       .AsImplementedInterfaces()
                       .InstancePerLifetimeScope();
            });

            builder.Register(x => MapperConfigurationFactory.CreateConfiguration(assembly))
                   .As<MapperConfiguration>()
                   .SingleInstance();

            builder.Register(x => { return x.Resolve<MapperConfiguration>().CreateMapper(); })
                   .As<IMapper>()
                   .SingleInstance();
        }
    }
}