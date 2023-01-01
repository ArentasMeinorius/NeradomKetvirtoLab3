using NeradomKetvirtoLab3.Database;
using NeradomKetvirtoLab3.Models;

namespace NeradomKetvirtoLab3.Repositories;

public class UserAuthsRepository : IUserAuthsRepository
{
    public UserAuthsRepository()
    {
        using var context = new ProjectDbContext();
        
        var usersAuths = new List<UserAuth>
        {
            new()
            {
                Id = new Guid("5fb7097c-335c-4d07-b4fd-000004e2d28c"),
                SecurityCode = "abc123"
            }
        };
        
        context.UsersAuths.AddRange(usersAuths);
        context.SaveChanges();
    }

    public IEnumerable<UserAuth> GetAll()
    {
        using var context = new ProjectDbContext();
        return context.UsersAuths;
    }
}