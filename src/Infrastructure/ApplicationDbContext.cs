using cart_api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace cart_api.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Variant> Variants { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
    }
}
