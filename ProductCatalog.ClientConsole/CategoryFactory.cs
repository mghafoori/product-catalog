using ProductCatalog.Entities;

namespace ProductCatalog.ClientConsole
{
    public class CategoryFactory : IFactory<Category>
    {
        public Category Create()
        {
            return new Category();
        }
    }
}
