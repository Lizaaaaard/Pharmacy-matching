using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.IdentityModel.Tokens;
using Persistance;

namespace Application.Servicies;

public class UserService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly AppDbContext _context;

    public UserService(UserManager<User> userManager, SignInManager<User> signInManager, AppDbContext context)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _context = context;
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
}