using Application.Servicies;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("PharmacyMatching")]
[ApiController]
public class RolesController: ControllerBase
{
    private readonly RoleManager<IdentityRole<int>> _roleManager;
    private readonly UserManager<User> _userManager;
    private readonly UserService _userService;
    private readonly EmailService _email;

    public RolesController(RoleManager<IdentityRole<int>> roleManager, UserManager<User> userManager, UserService userService, EmailService email)
    {
        _roleManager = roleManager;
        _userManager = userManager;
        _userService = userService;
        _email = email;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(string name)
    {
        if (!string.IsNullOrEmpty(name))
        {
            IdentityResult result = await _roleManager.CreateAsync(new IdentityRole<int>(name));
            if (result.Succeeded)
            {
                return Ok();
            }
        }

        return BadRequest();
    }
    
    [HttpPost("delete")]
    public async Task<IActionResult> Delete(string id)
    {
        IdentityRole<int> role = await _roleManager.FindByIdAsync(id);
        if (role != null)
        {
            IdentityResult result = await _roleManager.DeleteAsync(role);
        }

        return Ok();
    }
    
    [HttpPost("edit")]
    public async Task<IActionResult> Edit(string userId, List<string> roles)
    {
        User user = await _userManager.FindByIdAsync(userId);
        if (user != null)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            var allRoles = _roleManager.Roles.ToList();
            var addedRoles = roles.Except(userRoles);
            var removedRoles = userRoles.Except(roles);

            await _userManager.AddToRolesAsync(user, addedRoles);
            await _userManager.RemoveFromRolesAsync(user, removedRoles);

            return Ok();
        }

        return BadRequest();
    }

    [HttpGet("roles")]
    public async Task<List<string>> GetRolesList()
    {
        return _roleManager.Roles.Select(r => r.Name).ToList();
    }
    
    [HttpGet("users")]
    public async Task<List<string>> GetUsersList()
    {
        return _userManager.Users.Select(u => u.UserName).ToList();
    }

    [HttpGet("manage/roles")]
    public async Task<List<RolesDto>> GetUsersWithRoles()
    {
        return await _userService.GetListUsersRolesAsync();
    }

    [HttpPost("manage/roles")]
    // [Authorize(Roles = "Admin")]
    public async Task AssignRoleToUser([FromBody]NewUserRoleDto request)
    {
        await _userService.AssignRoleAsync(request);
    }
}