using System;
using System.Data.Entity;

namespace DotNet.Repository
{
    public interface IDbContextFactory
    {
        DbContext GetDbContext(Type contextType);

        DbContext GetDbContext<T>();

        void Clear();
    }
}
