using Std.Core;
using Std.Data.Domain;
using Std.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Std.Application.Basket
{
    public class BasketService : BaseAppService<BasketDto, Data.Domain.Basket>, IBasketService
    {
        public BasketService(IRepository<Data.Domain.Basket, int> repository) : base(repository)
        {
        }

        public BasketDto AddToBasket(int productId, int userId, int quantity)
        {
            int id =_repository.Add(new Data.Domain.Basket()
            {
                ProductId = productId,
                UserId = userId,
                Quantity = quantity
            });

            return _repository.GetById(id).MapTo<BasketDto>();
        }

        public BasketDto ChangeQuantity(int basketId, int quantity)
        {
            var basket = _repository.GetById(basketId);
            basket.Quantity = quantity;
            _repository.Update(basket);
            return basket.MapTo<BasketDto>();
        }

        public decimal GetTotalPrice(int userID)
        {
            var basketItems = _repository.Where(s => s.UserId == userID);
            return basketItems.Sum(s => s.Quantity * s.Product.Price);
        }
    }
}
