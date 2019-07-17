using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Std.Application.Product;
using Std.Data.Domain;
using Std.Shared.Dto;

namespace Std.Web.WebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;

        }
        // GET: api/Product
        [HttpGet]
        public List<Product> Get()
        {
            return _productService.GetAll();
        }

        // POST: api/Product
        [HttpPost]
        public bool Post([FromBody] ProductDto value)
        {
            int id = _productService.Insert(value);
            return id > 0 ? true : false;
        }

    }
}
