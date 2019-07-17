using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Std.Application.Basket;

namespace Std.Web.WebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        // GET: api/Basket
        [HttpGet]
        public decimal Get(int userID)
        {
            return _basketService.GetTotalPrice(userID);
        }

        // POST: api/Basket
        [HttpPost]
        public void Post([FromBody] int productId, int userId, int quantity)
        {
            _basketService.AddToBasket(productId, userId, quantity);
        }

        // PUT: api/Basket/5
        [HttpPut("{id}")]
        public void Put([FromBody] int basketId, int quantity)
        {
            _basketService.ChangeQuantity(basketId, quantity);
        }
        
    }
}
