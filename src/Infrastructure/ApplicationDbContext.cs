using System;
using cart_api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>().HasData(
                new Cart
                {
                    Guid = new Guid("de8adcfa-a172-4e41-9139-35d0b7a3b58f"),
                    Status = "OPEN",
                    CustomerId = 1
                });

            modelBuilder.Entity<Variant>().HasData(
                new Variant
                {
                    Id = 1,
                    Barcode = "foobarcode",
                    IsActive = true,
                    StockQuantity = 3
                });
            
            modelBuilder.Entity<CartItem>().HasData(
                new CartItem
                {
                    Id = 1,
                    CartGuid = new Guid("de8adcfa-a172-4e41-9139-35d0b7a3b58f"),
                    VariantId = 1
                });
        }
    }
}
