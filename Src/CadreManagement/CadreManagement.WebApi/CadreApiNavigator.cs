using CadreManagement.Web.HyperMediaApi;
using CadreManagement.WebApi.Models;

namespace CadreManagement.WebApi
{
    public class CadreApiNavigator:LinkNavigator<CadreResource>
    {
        public CadreApiNavigator(Link<CadreResource> link) : base(link)
        {
        }
    }
}