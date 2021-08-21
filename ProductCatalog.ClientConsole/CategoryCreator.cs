using ProductCatalog.Entities;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProductCatalog.ClientConsole
{
    public class CategoryCreator : AbstractEntityCreator<Category>
    {
        private readonly HttpClient _httpClient;
        private readonly IFactory<Category> _factory;
        private readonly string _name;

        public CategoryCreator(HttpClient httpClient, IFactory<Category> factory, string name)
        {
            _httpClient = httpClient;
            _factory = factory;
            _name = name;
        }

        protected override bool CreateEntity()
        {
            _entity = _factory.Create();
            _entity.Name = $"{_name} {Guid.NewGuid().ToString().Substring(0, 4)}";
            return true;
        }

        protected override async Task<bool> SaveAsync()
        {
            var content = new StringContent(_serializedEntity, null, "application/json");
            var result = await _httpClient.PostAsync(
                "http://localhost:3683/category",
                content
            );
            if (result.IsSuccessStatusCode)
            {
                var responseContent = await result.Content.ReadAsStringAsync();
                _entity.Id = int.Parse(responseContent);
                return true;
            }
            else
            {
                Console.WriteLine($"Failed to add a new category. Status code: {result.StatusCode}");
                return false;
            }
        }
    }
}
