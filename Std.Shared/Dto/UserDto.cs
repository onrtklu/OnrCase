using Std.Core;
using Std.Data.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Std.Shared.Dto
{
    [AutoMap(typeof(User))]
    public class UserDto : BaseDto
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime CreateDate { get; set; }

        public List<Basket> Baskets { get; set; }
    }
}
