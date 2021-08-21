using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProductCatalog.ClientConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var httpClient = new HttpClient();
            var catCreator = new CategoryCreator(httpClient,
                                                 new CategoryFactory(),
                                                 "Category");
            catCreator.OnSuccess += async () =>
            {
                var category = catCreator.Entity;
                var prodCreator = new ProductCreator(httpClient,
                                                     new DefaultProductBuilder(),
                                                     "Product",
                                                     12.99M,
                                                     category.Id);
                if (await prodCreator.CreateAsync())
                {
                    Console.WriteLine("Success!");
                }
            };
            catCreator.OnFailure += () => Console.WriteLine("Failed!");
            await catCreator.CreateAsync();
        }
    }
}
