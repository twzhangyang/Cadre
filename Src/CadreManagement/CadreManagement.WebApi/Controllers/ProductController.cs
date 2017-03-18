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

        [HttpGet,Route("home",Name = "B2AE8D4C-CE80-4EE9-9973-65A29858F4D9")]
        public ProductHomeResource Home()
        {
            return new ProductHomeResource(Url);
        }

        [HttpGet,Route("products",Name = "9094C01E-EB66-42D7-8911-0144F8317DAC")]
        public ProductsResource GetProducts()
        {
            var products = _productProvider.GetProducts();

            var resource=new ProductsResource(Url,products);
            return resource;
        }

        [HttpGet,Route("products/{id}",Name = "8EA9168B-B1F0-4E3D-AFCD-6842405908BE")]
        public ProductResource GetProduct(int id)
        {
            var product = _productProvider.GetProducts()
                .Single(x=>x.ProductId==id);
            var resource=new ProductResource(Url,product);

            return resource;
        }

        [HttpPost,Route("products/add",Name = "A744DA75-BD38-4259-AAA7-14B73C1FCE74")]
        public ProductAddedResponse AddProduct(ProductAddedCommand command)
        {
            var product= _productProvider.AddProduct(command);
            var response=new ProductAddedResponse(Url, product);

            return response;
        }

        [HttpPost,Route("products/remove",Name = "AC260BDA-355F-4D84-8B3B-D41B5B628AAF")]
        public ProductRemovedResponse RemoveProduct(ProductRemovedCommand command)
        {
            var result = _productProvider.RemoveProduct(command);
            var response=new ProductRemovedResponse(Url, result);

            return response;
        }
     
    }
}