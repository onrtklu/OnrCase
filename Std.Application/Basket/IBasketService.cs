using Std.Core;
using Std.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Std.Application.Basket
{
    public interface IBasketService : IAppService<BasketDto>, IService
    {
        BasketDto ChangeQuantity(int basketId, int quantity);
        BasketDto AddToBasket(int productId, int userId, int quantity);
        decimal GetTotalPrice(int userID);
    }
}
