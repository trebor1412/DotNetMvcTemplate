using DotNet.Core;
using DotNet.MyProject.Entity;
using DotNet.MyProject.Service;
using System.Web.Http;

namespace DotNet.MyProject.Api
{
    public class UserController : ApiController
    {
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        private IUserService userService { get; }

        [HttpGet, Route("api/user/{id}")]
        public User Get(int id)
        {
            return userService.GetUser(id);
        }

        [HttpPost, Route("api/user/create/{name}")]
        public IResult Create(string name)
        {
            return userService.CreateUser(name);
        }
    }
}