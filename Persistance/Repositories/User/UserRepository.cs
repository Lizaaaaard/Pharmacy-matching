using Domain.Entities;

namespace Persistance.Repositories.User;

public class UserRepository: IUserRepository
{
    private AppDbContext _ctx;
    public UserRepository(AppDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task AddRoleToUser(UserRole assign)
    {
        await _ctx.UserRoles.AddAsync(assign);
        await _ctx.SaveChangesAsync();
    }

    public async Task<int> FindPharmAsync(int managerId)
    {
       var pharm = _ctx.UserRoles.Where(u => u.UserId == managerId)
            .Select(pharm => pharm.PharmId)
            .SingleOrDefault();
       return pharm ?? 0;
    }
}