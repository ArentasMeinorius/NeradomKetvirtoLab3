using NeradomKetvirtoLab3.Models;
using NeradomKetvirtoLab3.Repositories;

namespace NeradomKetvirtoLab3.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUsersRepository _usersRepository;
    private readonly IUserAuthsRepository _userAuthsRepository;
    
    public AuthenticationService(IUsersRepository usersRepository, IUserAuthsRepository userAuthsRepository)
    {
        _usersRepository = usersRepository;
        _userAuthsRepository = userAuthsRepository;
    }

    public async Task<UserWithAuth?> Authenticate(UserAuth newUserAuth)
    {
        var userAuth = (await _userAuthsRepository.GetAll())
            .FirstOrDefault(user => user.Id == newUserAuth.Id && user.SecurityCode == newUserAuth.SecurityCode);
        
        if (userAuth is null)
            return null;
        
        var user = (await _usersRepository.GetAll())
            .FirstOrDefault(user => user.Id == userAuth.Id);
        
        return user == null ? null : new UserWithAuth(user, userAuth.SecurityCode);
    }

    public async Task<User?> AddRole(Guid userId, string role)
    {
        var user = (await _usersRepository.GetAll())
            .FirstOrDefault(user => userId.Equals(userId));

        if (user == null)
        {
            return null;
        }

        user.Role = role;
        await _usersRepository.Update(user);
        return user;
    }
}