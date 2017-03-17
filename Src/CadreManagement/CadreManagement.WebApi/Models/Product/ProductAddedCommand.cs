using System;
using System.Collections.Generic;
using System.Web.Http.Routing;
using CadreManagement.Web.HyperMediaApi;
using CadreManagement.WebApi.Controllers;

namespace CadreManagement.WebApi.Models.Product
{
    public class ProductAddedCommand:HyperMediaCommand<ProductAddedResponse>
    {
        private readonly UrlHelper _urlHelper;

        [Obsolete("For Serialization")]
        public ProductAddedCommand()
        {
            
        }

        public ProductAddedCommand(UrlHelper urlHelper):base(urlHelper.Link((ProductController c)=>c.AddProduct(null)))
        {
            _urlHelper = urlHelper;
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }
}