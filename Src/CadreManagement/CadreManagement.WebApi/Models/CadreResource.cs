using System;
using System.Web.Http.Routing;
using CadreManagement.Web.HyperMediaApi;
using CadreManagement.WebApi.Controllers;
using CadreManagement.WebApi.Models.Product;
using TypeLite;

namespace CadreManagement.WebApi.Models
{
    [TsClass]
    public class CadreResource
    {

        [Obsolete("For Serialization")]
        public CadreResource()
        {
        }

        public CadreResource(UrlHelper urlHelper)
        {
            ResourceLinks=new Links(urlHelper);
        }

        public Links ResourceLinks { get; set; }

        public class Links
        {
            [Obsolete("For Serialization")]
            public Links()
            {
                
            }

            public Links(UrlHelper urlHelper)
            {
                Self = urlHelper.Link((CadreHomeController c) => c.Index());
                ProductHome = urlHelper.Link((ProductController c) => c.Home());
            }

            public Link<CadreResource> Self { get; set; }
            public Link<ProductHomeResource> ProductHome { get; set; }
        }
    }
}