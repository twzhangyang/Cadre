using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web.Http.Routing;
using CadreManagement.Core.Extensions;
using CadreManagement.WebApi.Models;
using CadreManagement.WebApi.Models.Product;

namespace CadreManagement.WebApi.Providers
{
    public class ProductProvider
    {
        private readonly UrlHelper _urlHelper;
        private static readonly List<Product> Products = new List<Product>();

        public ProductProvider(UrlHelper urlHelper)
        {
            _urlHelper = urlHelper;
        }

        public Product AddProduct(ProductAddedCommand command)
        {
            var id = Products.Count;
            var product=new Product()
            {
                ProductId = id+1,
                ProductName = command.ProductName,
                ProductCode = command.ProductCode,
                ReleaseDate = DateTime.Now,
                Description = "Leaf rake with 48-inch wooden handle.",
                Price = 19.95m,
                StarRating = 3.2m,
                ImageUrl = "http://openclipart.org/image/300px/svg_to_png/26215/Anonymous_Leaf_Rake.png"
            };

            Products.Add(product);

            return product;
        }

        public bool RemoveProduct(ProductRemovedCommand command)
        {
            if (Products.None(x => x.ProductId == command.ProductId))
            {
                return false;
            }

            Products.Remove(Products.Single(x => x.ProductId == command.ProductId));

            return true;
        }

        public List<Product> GetProducts()
        {
            if (Products.Any())
            {
                return Products;
            }

            Products.Add(new Product()
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

            Products.Add(new Product()
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

            Products.Add(new Product()
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

            Products.Add(new Product()
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
            Products.Add(new Product()
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
            Products.Add(new Product()
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
            Products.Add(new Product()
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
            Products.Add(new Product()
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
            Products.Add(new Product()
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
            Products.Add(new Product()
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

            return Products;
        }
    }
}