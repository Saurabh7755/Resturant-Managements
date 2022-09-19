using Microsoft.EntityFrameworkCore;
using Restaurant.Web.Models;
using Resturant.Web.Models;

namespace Restaurant.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Resturant.Web.Models.Customer> Customer { get; set; }
    }
}