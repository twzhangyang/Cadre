using System.Collections.Generic;
using System.Web.Http;
using CadreManagement.WebApi.Models.Product;

namespace CadreManagement.WebApi.Controllers
{
    [RoutePrefix("api/demo")]
    public class HyperMediaDemoController:ApiController
    {
        private readonly CadreApiNavigator _apiNavigator;

        public HyperMediaDemoController(CadreApiNavigator apiNavigator)
        {
            _apiNavigator = apiNavigator;
        }

        [HttpGet,Route("producthome")]
        public ProductHomeResource GetProductHome()
        {
            var product = _apiNavigator
                .FollowLink(cadre => cadre.ResourceLinks.ProductHome)
                .Execute();

            return product;
        }

        [HttpGet,Route("products")]
        public ProductsResource GetProducts()
        {
            var products = _apiNavigator
                .FollowLink(cadre => cadre.ResourceLinks.ProductHome)
                .FollowLink(productHome => productHome.ResourceLinks.Products)
                .Execute();

            return products;
        }

        [HttpGet,Route("product/{id}")]
        public ProductResource GetProduct(int id)
        {
            var product = _apiNavigator
                .FollowLink(cadre => cadre.ResourceLinks.ProductHome)
                .FollowLinkTemplate(productHome => productHome.ResourceLinks.Product, id)
                .Execute();

            return product;
        }
    }
}