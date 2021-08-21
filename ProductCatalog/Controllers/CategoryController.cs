using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Entities;
using ProductCatalog.Repository;
using System.Collections.Generic;

namespace ProductCatalog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IRepository<Category, int> _repository;

        public CategoryController(IRepository<Category, int> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _repository.GetAll();
        }

        [HttpPost]
        public int Add(Category category)
        {
            _repository.Add(category);
            return category.Id;
        }
    }
}
