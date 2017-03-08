using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CadreManagement.WebApi.Models;

namespace CadreManagement.WebApi.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductController:ApiController
    {
        [HttpGet,Route("products")]
        public List<Product> GetProducts()
        {
            return CreateProducts();
        }

        [HttpGet,Route("products/{id}")]
        public Product GetProduct(int id)
        {
            return CreateProducts().First(x => x.ProductId == id);
        }

        private List<Product> CreateProducts()
        {
            var products = new List<Product>();
            products.Add(new Product()
            {
                ProductId = 1,
                ProductName = "Leaf Rake",
                ProductCode = "GDN-0011",
                ReleaseDate = DateTime.Now,
                Description = "Leaf rake with 48-inch wooden handle.",
                Price = 19.95m,
                StarRating = 3.2m,
                ImageUrl = "http://openclipart.org/image/300px/svg_to_png/26215/Anonymous_Leaf_Rake.png"
            });

            products.Add(new Product()
            {
                ProductId = 2,
                ProductName = "Leaf Rake2",
                ProductCode = "GDN-0011",
                ReleaseDate = DateTime.Now,
                Description = "Leaf rake with 48-inch wooden handle.",
                Price = 19.95m,
                StarRating = 3.2m,
                ImageUrl = "http://openclipart.org/image/300px/svg_to_png/26215/Anonymous_Leaf_Rake.png"
            });

            products.Add(new Product()
            {
                ProductId = 3,
                ProductName = "Leaf Rake2",
                ProductCode = "GDN-0011",
                ReleaseDate = DateTime.Now,
                Description = "Leaf rake with 48-inch wooden handle.",
                Price = 19.95m,
                StarRating = 3.2m,
                ImageUrl = "http://openclipart.org/image/300px/svg_to_png/26215/Anonymous_Leaf_Rake.png"
            });

            products.Add(new Product()
            {
                ProductId = 4,
                ProductName = "Leaf Rake4",
                ProductCode = "GDN-0011",
                ReleaseDate = DateTime.Now,
                Description = "Leaf rake with 48-inch wooden handle.",
                Price = 19.95m,
                StarRating = 3.2m,
                ImageUrl = "http://openclipart.org/image/300px/svg_to_png/26215/Anonymous_Leaf_Rake.png"
            });
            products.Add(new Product()
            {
                ProductId = 5,
                ProductName = "Leaf Rake5",
                ProductCode = "GDN-0011",
                ReleaseDate = DateTime.Now,
                Description = "Leaf rake with 48-inch wooden handle.",
                Price = 19.95m,
                StarRating = 3.2m,
                ImageUrl = "http://openclipart.org/image/300px/svg_to_png/26215/Anonymous_Leaf_Rake.png"
            });
            products.Add(new Product()
            {
                ProductId = 6,
                ProductName = "Leaf Rake6",
                ProductCode = "GDN-0011",
                ReleaseDate = DateTime.Now,
                Description = "Leaf rake with 48-inch wooden handle.",
                Price = 19.95m,
                StarRating = 3.2m,
                ImageUrl = "http://openclipart.org/image/300px/svg_to_png/26215/Anonymous_Leaf_Rake.png"
            });
            products.Add(new Product()
            {
                ProductId = 7,
                ProductName = "Leaf Rake7",
                ProductCode = "GDN-0011",
                ReleaseDate = DateTime.Now,
                Description = "Leaf rake with 48-inch wooden handle.",
                Price = 19.95m,
                StarRating = 3.2m,
                ImageUrl = "http://openclipart.org/image/300px/svg_to_png/26215/Anonymous_Leaf_Rake.png"
            });
            products.Add(new Product()
            {
                ProductId = 8,
                ProductName = "Leaf Rake8",
                ProductCode = "GDN-0011",
                ReleaseDate = DateTime.Now,
                Description = "Leaf rake with 48-inch wooden handle.",
                Price = 19.95m,
                StarRating = 3.2m,
                ImageUrl = "http://openclipart.org/image/300px/svg_to_png/26215/Anonymous_Leaf_Rake.png"
            });
            products.Add(new Product()
            {
                ProductId = 9,
                ProductName = "Leaf Rake9",
                ProductCode = "GDN-0011",
                ReleaseDate = DateTime.Now,
                Description = "Leaf rake with 48-inch wooden handle.",
                Price = 19.95m,
                StarRating = 3.2m,
                ImageUrl = "http://openclipart.org/image/300px/svg_to_png/26215/Anonymous_Leaf_Rake.png"
            });
            products.Add(new Product()
            {
                ProductId = 10,
                ProductName = "Leaf Rake10",
                ProductCode = "GDN-0011",
                ReleaseDate = DateTime.Now,
                Description = "Leaf rake with 48-inch wooden handle.",
                Price = 19.95m,
                StarRating = 3.2m,
                ImageUrl = "http://openclipart.org/image/300px/svg_to_png/26215/Anonymous_Leaf_Rake.png"
            });
            return products;
        }
    }
}