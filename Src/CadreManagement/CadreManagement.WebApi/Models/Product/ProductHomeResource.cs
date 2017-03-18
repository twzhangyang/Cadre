﻿using System;
using System.Collections.Generic;
using System.Web.Http.Routing;
using CadreManagement.Web.HyperMediaApi;
using CadreManagement.WebApi.Controllers;

namespace CadreManagement.WebApi.Models.Product
{
    public class ProductHomeResource
    {
        [Obsolete("For Serialization")]
        public ProductHomeResource()
        {
        }

        public ProductHomeResource(UrlHelper urlHelper)
        {
            ResourceLinks = new Links(urlHelper);
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
                Self = urlHelper.Link((ProductController c) => c.Home());
                Products = urlHelper.Link((ProductController c) => c.GetProducts());
                Product = urlHelper.LinkTemplate((ProductController c, int id) => c.GetProduct(id));
            }

            public Link<ProductHomeResource> Self { get; set; }
            public Link<ProductsResource> Products { get; set; }
            public LinkTemplate1<ProductResource, int> Product { get; set; }
        }
    }
}