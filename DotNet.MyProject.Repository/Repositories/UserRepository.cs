using DotNet.Core;
using DotNet.MyProject.Entity;
using DotNet.Repository;

namespace DotNet.MyProject.Repository
{
    public class UserRepository : RepositoryBase<MyDatabaseContext, User>, IUserRepository
    {
        public UserRepository(IDbContextFactory contextFactory, IExecutionContext executionContext)
            : base(contextFactory, executionContext)
        {
        }
    }
}