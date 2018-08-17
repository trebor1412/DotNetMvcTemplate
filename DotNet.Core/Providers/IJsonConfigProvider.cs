using System;

namespace DotNet.Core
{
    public interface IJsonConfigProvider
    {
        T Load<T>() where T : class, new();

        T LoadSection<T>() where T : class, new();

        object Load(Type type);

        object LoadSection(Type type);
    }
}