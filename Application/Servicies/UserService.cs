using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Persistance;
using Persistance.Repositories.User;

namespace Application.Servicies;

public class UserService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly RoleManager<IdentityRole<int>> _roleManager;
    private readonly AppDbContext _context;
    private readonly IUserRepository _repository;

    public UserService(UserManager<User> userManager, SignInManager<User> signInManager, 
        RoleManager<IdentityRole<int>> roleManager,AppDbContext context, IUserRepository repository)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _context = context;
        _repository = repository;
    }

    public async Task<bool> CreateUserAsync(RegisterDto regForm)
    {
        try
        {
            var user = new User
            {
                UserName = regForm.UserName,
                Email = regForm.Email,
                PhoneNumber = regForm.PhoneNumber
            };
            var result = await _userManager.CreateAsync(user, regForm.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); return false; }

    }

    public async Task<Tuple<User, bool>> VerifyPasswordAsync(LoginDto loginForm)
    {
        User user = _context.Users.SingleOrDefault(x => x.UserName == loginForm.UserName);
        if (user == null)
            return Tuple.Create(user, false);
        await _signInManager.PasswordSignInAsync(user, loginForm.Password, true, false);
        var result = await _signInManager.CheckPasswordSignInAsync(user, loginForm.Password, false);
        return Tuple.Create(user, result.Succeeded);
    }

    public UserDto GetUser(string login)
    {
        User user = _context.Users.SingleOrDefault(x => x.UserName == login);
        var result = new UserDto()
        {
            Id = user.Id,
            Login = user.UserName,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber
        };
        return result;
    }
    
    public async Task<string> GetUserRoleAsync(User user)
    {
        string result = (await _userManager
                .GetRolesAsync(user))
            .FirstOrDefault();
        if (!result.IsNullOrEmpty())
        {
            return result;
        }
        return "User";
    }

    public async Task<UserDto> ChangeInfo(UserDto newInfo)
    {
        var idUser = newInfo.Id.ToString();
        var user = await _userManager.FindByIdAsync(idUser);
        user.UserName = newInfo.Login;
        user.Email = newInfo.Email;
        user.PhoneNumber = newInfo.PhoneNumber;
        var update = await _userManager.UpdateAsync(user);
        await _context.SaveChangesAsync();
        return newInfo;
    }

    public async Task<List<RolesDto>> GetListUsersRolesAsync()
    {
        var list = await (from Users in _context.Users
                join UserRole in _context.UserRoles on Users.Id equals UserRole.UserId into tmpUR
                from UserRole in tmpUR.DefaultIfEmpty()
                join Pharmacy in _context.Pharmacies on UserRole.PharmId equals Pharmacy.Id into tmpPharm
                from Pharmacy in tmpPharm.DefaultIfEmpty()
                join Role in _context.Roles on UserRole.RoleId equals Role.Id
                select new
                {
                    UserId = Users.Id,
                    Role = Role.Name,
                    UserName = Users.UserName,
                    AssignDate = UserRole.AssignDate,
                    Pharmacy = Pharmacy.Name
                }
            ).ToListAsync();
        var result = new List<RolesDto>();
        foreach (var item in list)
        {
            result.Add(new RolesDto()
            {
                UserId = item.UserId,
                UserName = item.UserName,
                Role = item.Role,
                AssignDate = item.AssignDate.ToString("d") ,
                Pharmacy = item.Pharmacy
            });
        }
        return result;
    }

    public async Task AssignRoleAsync(NewUserRoleDto request)
    {
        var assign =  new UserRole()
        {
            UserId = request.UserId,
            RoleId = _roleManager.FindByNameAsync(request.Role).Result.Id,
            AssignDate =  DateTime.Now,
            PharmId = request.PharmId == 0 ? null: request.PharmId
        };
        await _repository.AddRoleToUser(assign);
    }

    public async Task<bool> CheckIfUserExist(string name, string email)
    {
        var exist = _userManager.Users
            .Where(u => u.UserName == name || u.Email == email).ToList();
        if (exist.Count == 0)
            return false;
        return true;
    }
    
}