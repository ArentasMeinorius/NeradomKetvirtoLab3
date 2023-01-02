using NeradomKetvirtoLab3.Models;

namespace NeradomKetvirtoLab3.Repositories;

public interface IUserAuthsRepository
{
    Task<IEnumerable<UserAuth>> GetAll();
}