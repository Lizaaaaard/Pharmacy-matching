using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("PharmacyMatching")]
[ApiController]
public class RolesController: ControllerBase
{
    private readonly RoleManager<IdentityRole<int>> _roleManager;
    private readonly UserManager<User> _userManager;

    public RolesController(RoleManager<IdentityRole<int>> roleManager, UserManager<User> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
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

}