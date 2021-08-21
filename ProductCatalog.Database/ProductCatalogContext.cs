using Microsoft.EntityFrameworkCore;
using ProductCatalog.Entities;

namespace ProductCatalog.Database
{
    public class ProductCatalogContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public ProductCatalogContext(DbContextOptions<ProductCatalogContext> context) : base(context)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Category>()
                .Property(c => c.Name)
                .IsRequired();
            modelBuilder
                .Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products);
        }
    }
}
