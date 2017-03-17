using System.Collections.Generic;
using System.Web.Http.Routing;
using CadreManagement.Web.HyperMediaApi;
using CadreManagement.WebApi.Controllers;

namespace CadreManagement.WebApi.Models.Product
{
    public class ProductAddedResponse
    {
        private readonly UrlHelper _urlHelper;

        public ProductAddedResponse(UrlHelper urlHelper,Product product)
        {
            _urlHelper = urlHelper;
            Product = product;
        }

        public Product Product { get; set; }

        public Links ResourceLinks => new Links()
        {
            Self = _urlHelper.Link((ProductController c)=>c.AddProduct(null)),
            RemoveProduct = _urlHelper.Link((ProductController c) => c.RemoveProduct(null)),
            Product = _urlHelper.Link((ProductController c)=>c.GetProduct(Product.ProductId))
        };

        public class Links
        {
            public Link<ProductAddedResponse> Self { get; set; }
            public Link<ProductResource> Product { get; set; }
            public Link<ProductRemovedResponse> RemoveProduct { get; set; }
        }
    }
}