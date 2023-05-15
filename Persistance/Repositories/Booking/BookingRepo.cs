using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories.Booking;
using Domain.Entities;

public class BookingRepo: IBookingRepo
{
    private AppDbContext _ctx;
    
    public BookingRepo(AppDbContext ctx)
    {
        _ctx = ctx;
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

    public async Task<Booking> getOrderDataAsync(int bookingId)
    {
        return _ctx.Bookings
            .Include(booking => booking.Orders)
            .ThenInclude(med => med.MedcToPharm)
            .Where(booking => booking.Id == bookingId).FirstOrDefault();
    }
}