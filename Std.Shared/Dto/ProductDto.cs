using Std.Core;
using Std.Data.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Std.Shared.Dto
{
    [AutoMap(typeof(Product))]
    public class ProductDto : BaseDto
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }

        public List<Basket> Baskets { get; set; }
    }
}
