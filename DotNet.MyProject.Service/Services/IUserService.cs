using DotNet.Core;
using DotNet.MyProject.Entity;

namespace DotNet.MyProject.Service
{
    public interface IUserService
    {
        User GetUser(int id);

        IResult CreateUser(string name);
    }
}