using System.Security.Policy;
using System.Web.Http;
using CadreManagement.WebApi.Models;

namespace CadreManagement.WebApi.Controllers
{
    [RoutePrefix("api/cadre")]
    public class CadreHomeController:ApiController
    {
        [HttpGet,Route("root")]
        public CadreResource Home()
        {
            return new CadreResource(Url);
        }
    }
}