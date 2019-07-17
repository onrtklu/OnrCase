using Std.Core;
using Std.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Std.Application.Product
{
    public class ProductService : BaseAppService<ProductDto, Data.Domain.Product>, IProductService
    {
        public ProductService(IRepository<Data.Domain.Product, int> repository) : base(repository)
        {
        }

        public List<Data.Domain.Product> GetAll()
        {
            return _repository.All().ToList();
        }

        public ProductDto InsertProduct(ProductDto product)
        {
            int id = Insert(product);
            return GetById(id);
        }
    }
}
