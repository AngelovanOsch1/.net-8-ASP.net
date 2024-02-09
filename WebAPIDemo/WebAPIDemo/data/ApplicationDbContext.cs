using Microsoft.EntityFrameworkCore;
using WebAPIDemo.Models.Shirts;

namespace WebAPIDemo.data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options) 
        {

        }
       
        public DbSet<Shirt> Shirts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Shirt>().HasData(
            new Shirt { ShirtId = 1, Brand = "My Brand", Color = "Blue", Gender = "Men", Price = 50 },
            new Shirt { ShirtId = 2, Brand = "My Brand", Color = "Blue", Gender = "Men", Price = 50 },
            new Shirt { ShirtId = 3, Brand = "My Brand", Color = "Blue", Gender = "Men", Price = 50 },
            new Shirt { ShirtId = 4, Brand = "My Brand", Color = "Blue", Gender = "Men", Price = 50 }
            );
        }
    }
}
