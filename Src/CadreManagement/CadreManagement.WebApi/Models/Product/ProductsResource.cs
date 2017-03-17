using System.Collections.Generic;
using System.Web.Http.Routing;
using CadreManagement.Web.HyperMediaApi;
using CadreManagement.WebApi.Controllers;

namespace CadreManagement.WebApi.Models.Product
{
    public class ProductsResource
    {
        private readonly UrlHelper _urlHelper;

        public ProductsResource(UrlHelper urlHelper,List<Product> products)
        {
            _urlHelper = urlHelper;
            Products = products;
        }

        public List<Product> Products { get; set; }

        public Links ResourceLinks => new Links()
        {
            Self = _urlHelper.Link((ProductController c) => c.GetProducts()),
            Product = _urlHelper.LinkTemplate((ProductController c, int id) => c.GetProduct(id)),
            AddProduct = _urlHelper.Link((ProductController c) => c.AddProduct(null)),
            RemoveProduct = _urlHelper.Link((ProductController c) => c.RemoveProduct(null))
        };

        public class Links
        {
            public Link<ProductsResource> Self { get; set; }
            public LinkTemplate1<ProductResource, int> Product { get; set; }
            public Link<ProductAddedResponse> AddProduct { get; set; }
            public Link<ProductRemovedResponse> RemoveProduct { get; set; }
        }
    }
}