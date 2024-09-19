using Domain.Entities;

namespace Persistance.Repositories.User;

public interface IUserRepository
{
    Task AddRoleToUser(UserRole assign);
    Task<int> FindPharmAsync(int managerId);
}