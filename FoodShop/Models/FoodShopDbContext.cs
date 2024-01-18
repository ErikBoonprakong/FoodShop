using Microsoft.EntityFrameworkCore;

namespace FoodShop.Models
{
    public class FoodShopDbContext : DbContext
    {
        public FoodShopDbContext (DbContextOptions<FoodShopDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Pie> Pies { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
