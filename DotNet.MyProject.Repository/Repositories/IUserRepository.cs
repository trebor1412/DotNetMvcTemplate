using DotNet.MyProject.Entity;
using DotNet.Repository;

namespace DotNet.MyProject.Repository
{
    public interface IUserRepository : IRepositoryBase<User>
    {
    }
}