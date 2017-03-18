using System;
using System.Collections.Generic;
using System.Web.Http.Routing;
using CadreManagement.Web.HyperMediaApi;
using CadreManagement.WebApi.Controllers;

namespace CadreManagement.WebApi.Models.Product
{
    public class ProductAddedResponse
    {
        [Obsolete("For Serialization")]
        public ProductAddedResponse()
        {
            
        }

        public ProductAddedResponse(UrlHelper urlHelper,Product product)
        {
            Product = product;
            ResourceLinks = new Links()
            {
                Product = urlHelper.Link((ProductController c) => c.GetProduct(product.ProductId))
            };
        }

        public Product Product { get; set; }

        public Links ResourceLinks { get; set; }

        public class Links
        {
            public Link<ProductResource> Product { get; set; }
        }
    }
}