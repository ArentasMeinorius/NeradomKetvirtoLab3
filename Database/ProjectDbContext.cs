using Microsoft.EntityFrameworkCore;
using NeradomKetvirtoLab3.Models;

namespace NeradomKetvirtoLab3.Database;

public class ProjectDbContext : DbContext
{
    protected override void OnConfiguring
        (DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "ProjectDb");
        optionsBuilder.EnableSensitiveDataLogging (true);
    }
    public DbSet<Author> Authors { get; set; }

    public DbSet<Book> Books { get; set; }

    public DbSet<Table> Tables { get; set; }

    public DbSet<Consumable> Consumables { get; set; }

    public DbSet<Visit> Visits { get; set; }

    public DbSet<Order> Orders { get;set; }

    public DbSet<User> Users { get; set; }

    public DbSet<UserAuth> UsersAuths { get; set; }
}