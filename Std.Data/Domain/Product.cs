using Std.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Std.Data.Domain
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }

        public List<Basket> Baskets { get; set; }
    }
}
