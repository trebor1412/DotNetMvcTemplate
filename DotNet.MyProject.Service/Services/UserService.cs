using DotNet.Core;
using DotNet.MyProject.Entity;
using DotNet.MyProject.Repository;
using DotNet.Service;
using System;
using System.Linq;

namespace DotNet.MyProject.Service
{
    public class UserService : ServiceBase, IUserService
    {
        public UserService(IUserRepository userRepository, IExecutionContext executionContext) : base(executionContext)
        {
            this.userRepository = userRepository;
        }

        private IUserRepository userRepository { get; }

        public IResult CreateUser(string name)
        {
            var newUser = new User { Name = name, CreateTime = executionContext.Now };

            try
            {
                userRepository.Add(newUser);
                return new Result { IsSuccess = true };
            }
            catch (Exception ex)
            {
                return new Result { Message = ex.Message };
            }
        }

        public User GetUser(int id)
        {
            var user = userRepository.GetAll()
                                     .FirstOrDefault(x => x.ID == id);
            return user;
        }
    }
}