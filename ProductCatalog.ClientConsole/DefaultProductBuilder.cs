using ProductCatalog.Entities;
using System;

namespace ProductCatalog.ClientConsole
{
    public class DefaultProductBuilder : IProductBuilder
    {
        private readonly Product _product = new Product();

        public IProductBuilder AddRandomCharactersToName()
        {
            _product.Name = $"{_product.Name} {Guid.NewGuid().ToString().Substring(0, 4)}" ;
            return this;
        }

        public IProductBuilder GenerateGuid()
        {
            _product.Id = Guid.NewGuid();
            return this;
        }

        public Product Get()
        {
            return _product;
        }

        public IProductBuilder WithCategoryId(int categoryId)
        {
            _product.CategoryId = categoryId;
            return this;
        }

        public IProductBuilder WithName(string name)
        {
            _product.Name = name;
            return this;
        }

        public IProductBuilder WithPrice(decimal price)
        {
            _product.Price = price;
            return this;
        }
    }
}
