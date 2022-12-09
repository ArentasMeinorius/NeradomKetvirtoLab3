using Microsoft.EntityFrameworkCore;
using NeradomKetvirtoLab3.Models;

namespace NeradomKetvirtoLab3.Database;

public class ProjectDbContext : DbContext
{
    protected override void OnConfiguring
        (DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "ProjectDb");
    }
    public DbSet<Author> Authors { get; set; }

    public DbSet<Book> Books { get; set; }
}