using DotNet.Core;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DotNet.Repository
{
    public abstract class RepositoryBase<TDbContext, TModel> : IRepositoryBase<TModel> where TModel : class, new()
    {
        public RepositoryBase(IDbContextFactory contextFactory, IExecutionContext executionContext)
        {
            context = contextFactory.GetDbContext<TDbContext>();
            dbSet = context.Set<TModel>();
            this.executionContext = executionContext;

            var modelInterfaces = typeof(TModel).GetInterfaces();
        }

        protected DbContext context { get; }
        protected DbSet<TModel> dbSet { get; }
        protected IExecutionContext executionContext { get; }

        private TModel BeforeAdd(TModel model)
        {
            return model;
        }

        private TModel BeforeUpdate(TModel model)
        {
            return model;
        }

        private void SaveChanges()
        {
            context.SaveChanges();
        }

        public IEnumerable<TModel> Add(IEnumerable<TModel> models)
        {
            models = models.Select(x => BeforeAdd(x));
            models = dbSet.AddRange(models);
            SaveChanges();
            return models;
        }

        public TModel Add(TModel model)
        {
            model = BeforeAdd(model);
            model = dbSet.Add(model);
            SaveChanges();
            return model;
        }

        public void Delete(TModel model)
        {
            context.Entry(model).State = EntityState.Deleted;
            SaveChanges();
        }

        public void Delete(IEnumerable<TModel> models)
        {
            dbSet.RemoveRange(models);
            SaveChanges();
        }

        public IQueryable<TModel> GetAll()
        {
            return dbSet.AsQueryable();
        }

        public void Update(TModel model)
        {
            model = BeforeUpdate(model);
            context.Entry(model).State = EntityState.Modified;
            SaveChanges();
        }
    }
}