using NeradomKetvirtoLab3.Models;

namespace NeradomKetvirtoLab3.Repositories;

public interface IUserAuthsRepository
{
    public IEnumerable<UserAuth> GetAll();
}