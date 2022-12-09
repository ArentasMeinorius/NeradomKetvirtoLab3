using NeradomKetvirtoLab3.Models;

namespace NeradomKetvirtoLab3.Repositories;

public interface IAuthorRepository
{
    List<Author> GetAuthors();
}