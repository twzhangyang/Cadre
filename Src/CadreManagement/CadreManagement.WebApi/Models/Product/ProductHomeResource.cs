using System.Collections.Generic;
using System.Web.Http.Routing;
using CadreManagement.Web.HyperMediaApi;
using CadreManagement.WebApi.Controllers;

namespace CadreManagement.WebApi.Models.Product
{
    public class ProductHomeResource
    {
        private readonly UrlHelper _urlHelper;

        public ProductHomeResource(UrlHelper urlHelper)
        {
            _urlHelper = urlHelper;
        }

        public Links ResourceLinks => new Links()
        {
            Self = _urlHelper.Link((ProductController c) => c.Home()),
            Products = _urlHelper.Link((ProductController c) => c.GetProducts()),
            Product = _urlHelper.LinkTemplate((ProductController c, int id) => c.GetProduct(id)),
            AddProduct = _urlHelper.Link((ProductController c) => c.AddProduct(null)),
            RemoveProduct = _urlHelper.Link((ProductController c) => c.RemoveProduct(null))
        };

        public class Links
        {
            public Link<ProductHomeResource> Self { get; set; }
            public Link<ProductsResource> Products { get; set; }
            public LinkTemplate1<ProductResource, int> Product { get; set; }
            public Link<ProductAddedResponse> AddProduct { get; set; }
            public Link<ProductRemovedResponse> RemoveProduct { get; set; }
        }
    }
}