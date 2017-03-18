using System;
using System.Web.Http.Routing;
using CadreManagement.Web.HyperMediaApi;
using CadreManagement.WebApi.Controllers;

namespace CadreManagement.WebApi.Models.Product
{
    public class ProductResource
    {
        [Obsolete("For Serialization")]
        public ProductResource()
        {
            
        }

        public ProductResource(UrlHelper urlHelper, Product product)
        {
            Product = product;
            ResourceLinks=new Links() { Self = urlHelper.Link((ProductController c) => c.GetProduct(Product.ProductId))};
        }

        public Product Product { get; set; }

        public Links ResourceLinks { get; set; }

        public class Links
        {
            public Link<ProductResource> Self { get; set; }
        }
    }
}