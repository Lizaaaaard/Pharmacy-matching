using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories.Booking;
using Domain.Entities;

public class BookingRepo: IBookingRepo
{
    private AppDbContext _ctx;
    private UserManager<User> _userManager;

    public BookingRepo(AppDbContext ctx, UserManager<User> userManager)
    {
        _ctx = ctx;
        _userManager = userManager;
    }
    
    public async Task saveOrder(Booking booking)
    {
        _ctx.Bookings.Add(booking);
        _ctx.SaveChangesAsync();
    }

    public async Task<List<Booking>> getBookingByUser(int userId)
    {
        return _ctx.Bookings
            .Include(booking => booking.Orders)
            .ThenInclude(order => order.MedcToPharm)
            .ThenInclude(medToPharm => medToPharm.Pharmacy)
            .Include(booking => booking.Orders)
            .ThenInclude(order => order.MedcToPharm)
            .ThenInclude(medToPharm => medToPharm.Doses)
            .Include(booking => booking.Orders)
            .ThenInclude(order => order.MedcToPharm)
            .ThenInclude(medToPharm => medToPharm.Medicine)
            .Where(booking => booking.UserId == userId).ToList();
    }
    
    public async Task<List<Booking>> getAllUsersBooking()
    {
        return _ctx.Bookings
            .Include(booking => booking.Orders)
            .ThenInclude(order => order.MedcToPharm)
            .ThenInclude(medToPharm => medToPharm.Pharmacy)
            .Include(booking => booking.Orders)
            .ThenInclude(order => order.MedcToPharm)
            .ThenInclude(medToPharm => medToPharm.Doses)
            .Include(booking => booking.Orders)
            .ThenInclude(order => order.MedcToPharm)
            .ThenInclude(medToPharm => medToPharm.Medicine)
            .ToList();
    }

    public async Task<List<Booking>> getAllUsersBookingByPharm(int pharmId)
    {
        var bookingList = _ctx.Bookings
            .Include(booking => booking.Orders)
            .ThenInclude(order => order.MedcToPharm)
            //.Where(booking => booking.Orders.Any(order => order.MedcToPharm.PharmId == pharmId))
            //.ThenInclude(order => order.MedcToPharm)
            .ThenInclude(medToPharm => medToPharm.Pharmacy)
            .Include(booking => booking.Orders)
            .ThenInclude(order => order.MedcToPharm)
            .ThenInclude(medToPharm => medToPharm.Doses)
            .Include(booking => booking.Orders)
            .ThenInclude(order => order.MedcToPharm)
            .ThenInclude(medToPharm => medToPharm.Medicine)
            .ToList();
        bookingList.ForEach(booking =>
        {
            booking.Orders = booking.Orders.Where(order => order.MedcToPharm.PharmId == pharmId).ToList();
        });
        return bookingList.Where(booking => booking.Orders.Count > 0).ToList();
    }
    
    public async Task<Booking> getOrderDataAsync(int bookingId)
    {
        return _ctx.Bookings
            .Include(booking => booking.Orders)
            .ThenInclude(med => med.MedcToPharm)
            .Where(booking => booking.Id == bookingId).FirstOrDefault();
    }

    public async Task<string> getUserEmailById(int UserId)
    {
        var user =  _userManager.FindByIdAsync(UserId.ToString());
        return user.Result.Email;
    }
}