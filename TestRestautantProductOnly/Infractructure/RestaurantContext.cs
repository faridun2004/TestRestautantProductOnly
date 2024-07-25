using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TestRestautantProductOnly.Model;
using TestRestautantProductOnly.Model.Orders;
using TestRestautantProductOnly.Model.Shipments;

namespace TestRestautantProductOnly.Infractruct
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<ShipmentItem> ShipmentItems { get; set; }
        public DbSet<ShippingAddress> ShippingAddresses { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18,2)"); 
            });
            modelBuilder.Entity<Cart>(entity =>
                {
                    modelBuilder.Entity<Cart>().HasKey(c => c.Id);
                });
            modelBuilder.Entity<CartItem>().HasKey(c => c.CartItemId);
            modelBuilder.Entity<Cart>()
                        .HasOne(c => c.Users)
                        .WithMany(u => u.Carts)
                        .HasForeignKey(c => c.UserId)
                        .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Order>()
                        .HasOne(o => o.Users)
                        .WithMany(u => u.Orders)
                        .HasForeignKey(o => o.UserId)
                        .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
