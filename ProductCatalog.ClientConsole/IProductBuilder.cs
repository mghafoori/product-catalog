using ProductCatalog.Entities;

namespace ProductCatalog.ClientConsole
{
    public interface IProductBuilder
    {
        IProductBuilder GenerateGuid();
        IProductBuilder WithName(string name);
        IProductBuilder AddRandomCharactersToName();
        IProductBuilder WithPrice(decimal price);
        IProductBuilder WithCategoryId(int categoryId);
        Product Get();
    }
}
