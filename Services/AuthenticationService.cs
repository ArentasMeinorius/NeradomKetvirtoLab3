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

    public UserWithAuth? Authenticate(UserAuth newUserAuth)
    {
        var userAuth = _userAuthsRepository
            .GetAll()
            .FirstOrDefault(user => user.Id == newUserAuth.Id && user.SecurityCode == newUserAuth.SecurityCode);
        
        if (userAuth is null)
            return null;
        
        var user = _usersRepository
            .GetAll()
            .FirstOrDefault(user => user.Id == userAuth.Id);
        
        return user == null ? null : new UserWithAuth(user, userAuth.SecurityCode);
    }

    public User? AddRole(Guid userId, string role)
    {
        var user = _usersRepository.GetAll().FirstOrDefault(user => userId.Equals(userId));
        if (user == null)
        {
            return null;
        }
        user.Role = role;
        _usersRepository.Update(user);
        return user;
    }
}