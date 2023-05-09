using Domain.Entities;
using Microsoft.AspNetCore.Identity;
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

    public async Task<bool> VerifyPasswordAsync(LoginDto loginForm)
    {
        User user = _context.Users.SingleOrDefault(x => x.UserName == loginForm.UserName);
        if (user == null)
            return false;
        await _signInManager.PasswordSignInAsync(user, loginForm.Password, true, false);
        var result = await _signInManager.CheckPasswordSignInAsync(user, loginForm.Password, false);
        return result.Succeeded;
    }
}