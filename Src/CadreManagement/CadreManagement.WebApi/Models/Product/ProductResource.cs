using System.Web.Http.Routing;
using CadreManagement.Web.HyperMediaApi;
using CadreManagement.WebApi.Controllers;

namespace CadreManagement.WebApi.Models.Product
{
    public class ProductResource
    {
        private readonly UrlHelper _urlHelper;

        public ProductResource(UrlHelper urlHelper, Product product)
        {
            _urlHelper = urlHelper;
            Product = product;
        }

        public Product Product { get; set; }

        public Links ResourceLinks => new Links()
        {
            Self = _urlHelper.Link((ProductController c) => c.GetProduct(Product.ProductId)),
            RemoveProduct = _urlHelper.Link((ProductController c) => c.RemoveProduct(null))
        };

        public class Links
        {
            public Link<ProductResource> Self { get; set; }
            public Link<ProductRemovedResponse> RemoveProduct { get; set; }
        }
    }
}