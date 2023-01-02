using NeradomKetvirtoLab3.Models;

namespace NeradomKetvirtoLab3.Repositories;

public interface IUsersRepository
{
    Task<IEnumerable<User>> GetAll();

    Task<User?> Update(User newUser);
}