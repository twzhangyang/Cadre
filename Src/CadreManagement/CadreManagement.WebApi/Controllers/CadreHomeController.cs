using System.Security.Policy;
using System.Web.Http;
using CadreManagement.Web.HyperMediaApi;
using CadreManagement.WebApi.Models;

namespace CadreManagement.WebApi.Controllers
{
    public class CadreHomeController:ApiController
    {

        public static Link<CadreResource> Home()
        {
            return new Link<CadreResource>(WebApiRouteHelper.RootUri);
        }

        [HttpGet,Route("api",Name = "57BD9A8C-4F2F-4258-82CC-D6D89913E968")]
        public CadreResource Index()
        {
            return new CadreResource(Url);
        }
    }
}