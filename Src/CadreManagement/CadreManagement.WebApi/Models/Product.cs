using System;
using TypeLite;

namespace CadreManagement.WebApi.Models
{
    [TsClass]
    public class Product:ViewModel<Product>
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal StarRating { get; set; }
        public string ImageUrl { get; set; }
    }
}