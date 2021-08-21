using ProductCatalog.Database;
using ProductCatalog.Entities;
using System;
using System.Collections.Generic;

namespace ProductCatalog.Repository
{
    public class FakeCategoryRpository : IRepository<Category, int>
    {

        public FakeCategoryRpository()
        {
        }

        public void Add(Category category)
        {
            Console.WriteLine("Category added");
        }

        public void Delete(int id)
        {
            Console.WriteLine("Category deleted");
        }

        public Category Get(int id)
        {
            return new Category { Id = int.MaxValue, Name = "The Fake Category" };
        }

        public IEnumerable<Category> GetAll()
        {
            return new[]
            {
            new Category { Id = int.MaxValue - 1, Name = "The Fake Category 1" },
            new Category { Id = int.MaxValue - 2, Name = "The Fake Category 2" },
            new Category { Id = int.MaxValue - 3, Name = "The Fake Category 3" },
            new Category { Id = int.MaxValue - 4, Name = "The Fake Category 4" }

        };
        }

        public void Update(Category category)
        {
            Console.WriteLine("Category updated");
        }
    }
}
