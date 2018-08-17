using System.Collections.Generic;
using System.Linq;

namespace DotNet.Repository
{
    public interface IRepositoryBase<TModel> where TModel : class, new()
    {
        IQueryable<TModel> GetAll();

        TModel Add(TModel model);

        IEnumerable<TModel> Add(IEnumerable<TModel> models);

        void Update(TModel model);

        void Delete(TModel model);

        void Delete(IEnumerable<TModel> models);
    }
}