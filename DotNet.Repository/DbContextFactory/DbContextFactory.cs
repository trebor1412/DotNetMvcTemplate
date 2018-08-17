using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace DotNet.Repository
{
    public class DbContextFactory : IDbContextFactory
    {
        private Dictionary<Type, DbContext> _dbContexts = new Dictionary<Type, DbContext>();

        public void Clear()
        {
            _dbContexts.Clear();
        }

        public DbContext GetDbContext(Type contextType)
        {
            if (this._dbContexts.ContainsKey(contextType) == false)
            {
                var dbContext = (DbContext)Activator.CreateInstance(contextType);
                this._dbContexts.Add(contextType, dbContext);
            }

            return this._dbContexts[contextType];
        }

        public DbContext GetDbContext<T>()
        {
            var contextType = typeof(T);
            var dbContext = this.GetDbContext(contextType);

            return dbContext;
        }
    }
}