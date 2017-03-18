using System;
using System.Web.Http.Routing;
using CadreManagement.Web.HyperMediaApi;
using CadreManagement.WebApi.Controllers;
using Newtonsoft.Json;
using TypeLite;

namespace CadreManagement.WebApi.Models.Product
{
    [TsClass]
    public class ProductRemovedCommand:HyperMediaCommand<ProductRemovedResponse>
    {
        private readonly UrlHelper _urlHelper;

        [Obsolete("For serialization")]
        public ProductRemovedCommand()
        {
        }

        public ProductRemovedCommand(UrlHelper urlHelper):base(urlHelper.Link((ProductController c)=>c.RemoveProduct(null)))
        {
            _urlHelper = urlHelper;
        }

        public int ProductId { get; set; }
    }
}