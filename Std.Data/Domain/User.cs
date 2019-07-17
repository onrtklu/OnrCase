using Std.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Std.Data.Domain
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime CreateDate { get; set; }

        public List<Basket> Baskets { get; set; }
    }
}
