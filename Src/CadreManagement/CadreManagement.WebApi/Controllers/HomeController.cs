using System.Collections.Generic;
using System.Web.Http;
using CadreManagement.WebApi.Models.Product;

namespace CadreManagement.WebApi.Controllers
{
    [RoutePrefix("api/home")]
    public class HomeController:ApiController
    {
        private readonly CadreApiNavigator _apiNavigator;

        public HomeController(CadreApiNavigator apiNavigator)
        {
            _apiNavigator = apiNavigator;
        }

        [Route("sayHello")]
        [HttpGet]
        public List<string> SayHello()
        {
            var list = new List<string>();
            list.Add("Hello");
            list.Add("World");

            return list;
        }

        [HttpGet,Route("product")]
        public ProductHomeResource GetProduct()
        {
            var product = _apiNavigator
                .FollowLink(cadre => cadre.ResourceLinks.ProductHome)
                .Execute();

            return product;
        }
    }
}