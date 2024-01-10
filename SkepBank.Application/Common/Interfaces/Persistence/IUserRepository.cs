using SkepBank.Domain.Entities;

namespace SkepBank.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetByUserName(string userName);
    void Add(User user);
}
