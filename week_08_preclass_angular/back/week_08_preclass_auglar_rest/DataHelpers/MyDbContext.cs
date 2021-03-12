using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace week_08_back.DataHelpers
{
    public class Product
    {
        [Key]
        public int ProduceID { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }

    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new { ProduceID = 1, Description = "Oranges", Price = 1.11M },
                new { ProduceID = 2, Description = "Apples", Price = 1.22M },
                new { ProduceID = 3, Description = "Pears", Price = 1.33M }
            );
        }
    }
}
