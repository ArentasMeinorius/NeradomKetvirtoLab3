using NeradomKetvirtoLab3.Models;

namespace NeradomKetvirtoLab3.Services;

public interface IAuthenticationService
{
    public UserWithAuth? Authenticate(UserAuth newUserAuth);

    public User? AddRole(Guid userId, string role);
}