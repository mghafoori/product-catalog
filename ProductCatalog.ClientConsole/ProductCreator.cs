using ProductCatalog.Entities;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProductCatalog.ClientConsole
{
    public class ProductCreator : AbstractEntityCreator<Product>
    {
        private readonly HttpClient _httpClient;
        private readonly IProductBuilder _productBuilder;
        private readonly string _name;
        private readonly decimal _price;
        private readonly int _categoryId;

        public ProductCreator(HttpClient httpClient, IProductBuilder productBuilder,
            string name, decimal price, int categoryId)
        {
            _httpClient = httpClient;
            _productBuilder = productBuilder;
            _name = name;
            _price = price;
            _categoryId = categoryId;
        }

        protected override bool CreateEntity()
        {
            _entity = _productBuilder
                .GenerateGuid()
                .WithName(_name)
                .AddRandomCharactersToName()
                .WithPrice(_price)
                .WithCategoryId(_categoryId)
                .Get();
            return true;
        }

        protected override async Task<bool> SaveAsync()
        {
            var content = new StringContent(_serializedEntity, null, "application/json");
            var result = await _httpClient.PostAsync(
                "http://localhost:3683/product",
                content
            );
            return result.IsSuccessStatusCode;
        }
    }
}
