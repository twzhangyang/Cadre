using System.Web.Http.Routing;
using CadreManagement.Web.HyperMediaApi;
using CadreManagement.WebApi.Controllers;

namespace CadreManagement.WebApi.Models.Product
{
    public class ProductRemovedResponse
    {
        private readonly UrlHelper _urlHelper;

        public ProductRemovedResponse(UrlHelper urlHelper, bool result)
        {
            _urlHelper = urlHelper;
            Result = result;
        }

        public bool Result { get; set; }

        public Links ResourceLinks => new Links()
        {
            Self = _urlHelper.Link((ProductController c) => c.RemoveProduct(null)),
            Products = _urlHelper.Link((ProductController c) => c.GetProducts())
        };

        public class Links
        {
            public Link<ProductRemovedResponse> Self { get; set; }
            public Link<ProductsResource> Products { get; set; }
        }
    }
}