using NeradomKetvirtoLab3.Database;
using NeradomKetvirtoLab3.Models;
using Microsoft.EntityFrameworkCore;

namespace NeradomKetvirtoLab3.Repositories;

public class AuthorRepository : IAuthorRepository
{
    public AuthorRepository()
    {
        using (var context = new ProjectDbContext())
        {
            var authors = new List<Author>
            {
                new Author
                {
                    Name ="Joydip",
                    Books = new List<Book>()
                    {
                        new Book { Title = "Mastering C# 8.0"},
                        new Book { Title = "Entity Framework Tutorial"},
                        new Book { Title = "ASP.NET 4.0 Programming"}
                    }
                },
                new Author
                {
                    Name ="Yashavanth",
                    Books = new List<Book>()
                    {
                        new Book { Title = "Let us C"},
                        new Book { Title = "Let us C++"},
                        new Book { Title = "Let us C#"}
                    }
                }
            };
            context.Authors.AddRange(authors);
            context.SaveChanges();
        }
    }

    public List<Author> GetAuthors()
    {
        using var context = new ProjectDbContext();
        var list = context.Authors
            .Include(a => a.Books)
            .ToList();
        return list;
    }
}