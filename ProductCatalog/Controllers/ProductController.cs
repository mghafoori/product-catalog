using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Entities;
using ProductCatalog.Repository;

namespace ProductCatalog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IRepository<Product, Guid> _repository;

        public ProductController(IRepository<Product, Guid> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _repository.GetAll();
        }

        [HttpPost]
        public void Add(Product product)
        {
            if (product.Id == Guid.Empty)
            {
                throw new ArgumentException($"Invalid product Id: {product.Id}", nameof(product));
            }
            _repository.Add(product);
        }
    }
}
