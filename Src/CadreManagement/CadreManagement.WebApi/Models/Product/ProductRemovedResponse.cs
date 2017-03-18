using System;
using System.Web.Http.Routing;
using CadreManagement.Web.HyperMediaApi;
using CadreManagement.WebApi.Controllers;

namespace CadreManagement.WebApi.Models.Product
{
    public class ProductRemovedResponse
    {

        [Obsolete("For Serialization")]
        public ProductRemovedResponse()
        {
           
        }
        public ProductRemovedResponse(UrlHelper urlHelper, bool result)
        {
            Result = result;
            ResourceLinks=new Links(urlHelper);
        }

        public bool Result { get; set; }

        public Links ResourceLinks { get; set; }

        public class Links
        {
            [Obsolete("For Serialization")]
            public Links()
            {
                
            }
            public Links(UrlHelper urlHelper)
            {
                Products = urlHelper.Link((ProductController c) => c.GetProducts());
            }
            public Link<ProductsResource> Products { get; set; }
        }
    }
}