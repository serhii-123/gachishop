using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Gachishop;

public class ShopContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<ProductInventory> ProductInventories { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<UserPayment> UserPayments { get; set; }
    public DbSet<UserDeliveryData> UserDeliveryData { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(u => u.Id);
        modelBuilder.Entity<Product>().HasKey(p => p.Id);
        modelBuilder.Entity<ProductCategory>().HasKey(c => c.Id);
        modelBuilder.Entity<ProductInventory>().HasKey(i => i.Id);
        modelBuilder.Entity<Cart>().HasKey(c => c.Id);
        modelBuilder.Entity<CartItem>().HasKey(i => i.Id);
        modelBuilder.Entity<UserPayment>().HasKey(p => p.Id);
        modelBuilder.Entity<UserDeliveryData>().HasKey(d => d.Id);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Filename=Shop.db");
        base.OnConfiguring(optionsBuilder);
    }
}