using Std.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Std.Data.Domain
{
    public class Basket : BaseEntity
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
