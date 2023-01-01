using NeradomKetvirtoLab3.Models;

namespace NeradomKetvirtoLab3.Repositories;

public interface IUsersRepository
{
    public IEnumerable<User> GetAll();

    public User Update(User newUser);
}