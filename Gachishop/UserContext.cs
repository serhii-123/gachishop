using Microsoft.EntityFrameworkCore;

namespace Gachishop;

public class UserContext : DbContext
{
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(u => u.Id);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Filename=User.db");
        base.OnConfiguring(optionsBuilder);
    }
}