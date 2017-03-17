using System;
using System.Collections.Generic;
using System.Web.Http.Routing;
using CadreManagement.Web.HyperMediaApi;
using CadreManagement.WebApi.Controllers;
using TypeLite;

namespace CadreManagement.WebApi.Models.Product
{
    [TsClass]
    public class Product
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