using SkepBank.Application.Common.Interfaces.Persistence;
using SkepBank.Domain.Entities;

namespace SkepBank.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new List<User>();

    public void Add(User user)
    {
        _users.Add(user);
    }

    public User? GetByUserName(string userName)
    {
        return _users.SingleOrDefault(x => x.UserName == userName);
    }
}
