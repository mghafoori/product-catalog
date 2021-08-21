using ProductCatalog.Database;
using ProductCatalog.Entities;
using System.Collections.Generic;

namespace ProductCatalog.Repository
{
    public class CategoryRpository : IRepository<Category, int>
    {
        private readonly ProductCatalogContext _context;

        public CategoryRpository(ProductCatalogContext context)
        {
            _context = context;
        }

        public void Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var category = _context.Categories.Find(id);
            if (category != null)
            {
                _context.Remove(category);
                _context.SaveChanges();
            }

        }

        public Category Get(int id)
        {
            return _context.Categories.Find(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories;
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }
    }
}
