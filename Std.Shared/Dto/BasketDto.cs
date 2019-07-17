using Std.Core;
using Std.Data.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Std.Shared.Dto
{
    [AutoMap(typeof(Basket))]
    public class BasketDto : BaseDto
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
