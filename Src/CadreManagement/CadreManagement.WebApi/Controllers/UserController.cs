using System.Linq;
using System.Web.Http;
using CadreManagement.ApplicationService.Contracts;
using CadreManagement.Model;
using Castle.Core.Internal;

namespace CadreManagement.WebApi.Controllers
{
    [RoutePrefix("api/users")]
    public class UserController:ApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("register")]
        public bool Register10Users()
        {
            Enumerable.Range(1, 10).ForEach(x =>
            {
                _userService.Register(new UserModel()
                {
                    Email = $"admin{x}@google.com",
                    Name = $"Jim{x}",
                    Password = $"Password{x}"
                });
            });

            return true;
        }
    }
}