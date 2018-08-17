using Autofac;
using System.Linq;
using System.Reflection;

namespace DotNet.Core
{
    public class JsonConfigModuleBase : Autofac.Module
    {
        protected virtual string[] assemblies => new string[] { };

        protected override void Load(ContainerBuilder builder)
        {
            var settings =
                assemblies.Select(x => Assembly.Load(x))
                          .SelectMany(x => x.GetTypes())
                          .Where(t => t.Name.EndsWith("JsonConfig"))
                          .ToList();

            settings.ForEach(type =>
            {
                builder.Register(c => c.Resolve<IJsonConfigProvider>().LoadSection(type))
                       .As(type)
                       .InstancePerLifetimeScope();
            });
        }
    }
}