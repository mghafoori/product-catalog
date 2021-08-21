﻿using System.Collections.Generic;

namespace ProductCatalog.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Product> Products { get; set; }  // Navigation property
    }
}
