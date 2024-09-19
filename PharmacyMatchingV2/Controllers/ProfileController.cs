using Application.Servicies;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace API.Controllers;

[Route("PharmacyMatching")]
[ApiController]
public class ProfileController: ControllerBase
{
    private readonly UserService _userService;
    private readonly BookingService _bookingService;

    public ProfileController(UserService userService, BookingService bookingService)
    {
        _userService = userService;
        _bookingService = bookingService;
    }
    
    [HttpGet("user")]
    public ActionResult<UserDto> GetUserByLogin(string login)
    {
        return _userService.GetUser(login);
    }

    [HttpPost("editUserInfo")]
    public  async Task<ActionResult<UserDto>> EditUserData([FromBody] UserDto user)
    {
        return await _userService.ChangeInfo(user);
    }

    [HttpGet("user/history")]
    public async Task<List<HistoryDto>> GetUserBookingHistory(int userId)
    {
        return await _bookingService.showHistory(userId);
    }
    
    [HttpGet("users/orders")]
    public async Task<List<HistoryDto>> GetAllUsersOrders()
    {
        return await _bookingService.showOrders();
    }
    
    [HttpGet("users/orders/pharmacy")]
    public async Task<List<HistoryDto>> GetAllUsersOrdersByPharm(int managerId)
    {
        return await _bookingService.ordersByPharm(managerId);
    }

    [HttpPost("orders")]
    public async Task ChangeOrderStatus(int bookingId)
    {
         await _bookingService.changeStatusAsync(bookingId);
    }
}