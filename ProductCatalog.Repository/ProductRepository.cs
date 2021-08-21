using ProductCatalog.Database;
using ProductCatalog.Entities;
using System;
using System.Collections.Generic;

namespace ProductCatalog.Repository
{
    public class ProductRepository : IRepository<Product, Guid>
    {
        private readonly ProductCatalogContext _context;

        public ProductRepository(ProductCatalogContext context)
        {
            _context = context;
        }
        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            _context.SaveChanges();
        }

        public Product Get(Guid id)
        {
            return _context.Products.Find(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products;
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }
    }
}
