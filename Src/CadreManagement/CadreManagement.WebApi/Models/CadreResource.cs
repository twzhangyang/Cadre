using System.Web.Http.Routing;
using CadreManagement.Web.HyperMediaApi;
using CadreManagement.WebApi.Controllers;
using CadreManagement.WebApi.Models.Product;

namespace CadreManagement.WebApi.Models
{
    public class CadreResource
    {
        private readonly UrlHelper _urlHelper;

        public CadreResource(UrlHelper urlHelper)
        {
            _urlHelper = urlHelper;
        }

        public Links ResourceLinks => new Links()
        {
            Self = _urlHelper.Link((CadreHomeController c) => c.Home()),
            ProductHome = _urlHelper.Link((ProductController c) => c.Home())
        };

        public class Links
        {
            public Link<CadreResource> Self { get; set; }
            public Link<ProductHomeResource> ProductHome { get; set; }
        }
    }
}