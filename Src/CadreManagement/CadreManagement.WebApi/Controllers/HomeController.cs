using System.Collections.Generic;
using System.Web.Http;

namespace CadreManagement.WebApi.Controllers
{
    [RoutePrefix("api/home")]
    public class HomeController:ApiController
    {
        [Route("sayHello")]
        [HttpGet]
        public List<string> SayHello()
        {
            var list = new List<string>();
            list.Add("Hello");
            list.Add("World");

            return list;
        }
    }
}