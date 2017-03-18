using System;
using System.Collections.Generic;
using System.Web.Http.Routing;
using CadreManagement.Web.HyperMediaApi;
using CadreManagement.WebApi.Controllers;

namespace CadreManagement.WebApi.Models.Product
{
    public class ProductsResource
    {
        [Obsolete("For Serialization")]
        public ProductsResource()
        {
            
        }
        public ProductsResource(UrlHelper urlHelper,List<Product> products)
        {
            Products = products;
            ResourceLinks=new Links(urlHelper);
        }

        public List<Product> Products { get; set; }

        public Links ResourceLinks { get; set; }
        public class Links
        {
            [Obsolete("For Serialization")]
            public Links()
            {
                
            }

            public Links(UrlHelper urlHelper)
            {
                Self = urlHelper.Link((ProductController c) => c.GetProducts());
                Product = urlHelper.LinkTemplate((ProductController c, int id) => c.GetProduct(id));
                AddProduct = urlHelper.Link((ProductController c) => c.AddProduct(null));
                RemoveProduct = urlHelper.Link((ProductController c) => c.RemoveProduct(null));
            }

            public Link<ProductsResource> Self { get; set; }
            public LinkTemplate1<ProductResource, int> Product { get; set; }
            public Link<ProductAddedResponse> AddProduct { get; set; }
            public Link<ProductRemovedResponse> RemoveProduct { get; set; }
        }
    }
}