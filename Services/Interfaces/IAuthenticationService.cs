using NeradomKetvirtoLab3.Models;

namespace NeradomKetvirtoLab3.Services;

public interface IAuthenticationService
{
    Task<UserWithAuth?> Authenticate(UserAuth newUserAuth);

    Task<User?> AddRole(Guid userId, string role);
}