using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CadreManagement.WebApi.Models;
using CadreManagement.WebApi.Models.Product;
using CadreManagement.WebApi.Providers;

namespace CadreManagement.WebApi.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductController:ApiController
    {
        private readonly ProductProvider _productProvider;

        public ProductController(ProductProvider productProvider)
        {
            _productProvider = productProvider;
        }

        [HttpGet,Route("home")]
        public ProductHomeResource Home()
        {
            return new ProductHomeResource(Url);
        }

        [HttpGet,Route("products")]
        public ProductsResource GetProducts()
        {
            var products = _productProvider.GetProducts();

            var resource=new ProductsResource(Url,products);
            return resource;
        }

        [HttpGet,Route("products/{id}")]
        public ProductResource GetProduct(int id)
        {
            var product = _productProvider.GetProducts()
                .Single(x=>x.ProductId==id);
            var resource=new ProductResource(Url,product);

            return resource;
        }

        [HttpPost,Route("products/add")]
        public ProductAddedResponse AddProduct(ProductAddedCommand command)
        {
            var product= _productProvider.AddProduct(command);
            var response=new ProductAddedResponse(Url, product);

            return response;
        }

        [HttpPost,Route("products/remove")]
        public ProductRemovedResponse RemoveProduct(ProductRemovedCommand command)
        {
            var result = _productProvider.RemoveProduct(command);
            var response=new ProductRemovedResponse(Url, result);

            return response;
        }
     
    }
}