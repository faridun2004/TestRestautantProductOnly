using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TestRestautantProductOnly.Model;

namespace TestRestautantProductOnly.Infractruct
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18,2)"); // Указывает тип столбца как decimal с точностью 18 и масштабом 2
            });
            modelBuilder.Entity<Cart>(entity =>
                {
                    modelBuilder.Entity<Cart>().HasKey(c => c.Id);
                    //    entity.HasData(new Cart
                    //    {
                    //        Items = new List<CartItem>
                    //        {
                    //            new CartItem {CartItemId=1,DishId=3,Name="mant", Price=80, Quantity=5}
                    //        }
                    //    }) ;


                });
            modelBuilder.Entity<CartItem>().HasKey(c => c.CartItemId);
            modelBuilder.Entity<Order>().HasKey(c => c.OrderId);
            modelBuilder.Entity<OrderItem>().HasKey(c => c.OrderItemId);
        }
    }
}
