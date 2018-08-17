using Autofac;

namespace DotNet.Core
{
    public interface ITypeRegistrar
    {
        int Order { get; }

        void RegisterTypes(ContainerBuilder builder);
    }
}