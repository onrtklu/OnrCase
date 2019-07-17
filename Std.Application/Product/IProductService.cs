using Std.Core;
using Std.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Std.Application.Product
{
    public interface IProductService : IAppService<ProductDto>, IService
    {
        List<Data.Domain.Product> GetAll();
        ProductDto InsertProduct(ProductDto product);
    }
}
