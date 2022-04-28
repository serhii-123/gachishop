using Microsoft.EntityFrameworkCore;

namespace Gachishop;

public class UserContext :DbContext
{
    public DbSet<User> Users { get; set; }
    public UserContext()
    {
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Filename=User.db");
    }
}