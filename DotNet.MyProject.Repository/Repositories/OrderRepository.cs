using DotNet.Core;
using DotNet.MyProject.Entity;
using DotNet.Repository;

namespace DotNet.MyProject.Repository
{
    public class OrderRepository : RepositoryBase<MyDatabaseContext, Order>, IOrderRepository
    {
        public OrderRepository(IDbContextFactory contextFactory, IExecutionContext executionContext)
            : base(contextFactory, executionContext)
        {
        }
    }
}