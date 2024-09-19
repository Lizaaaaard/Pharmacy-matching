namespace Persistance.Repositories.Booking;

using Domain.Entities;
public interface IBookingRepo
{
    Task saveOrder(Booking booking);
    Task<List<Booking>> getBookingByUser(int userId);
    Task<List<Booking>> getAllUsersBooking();
    Task<List<Booking>> getAllUsersBookingByPharm(int pharmId);
    Task<Booking> getOrderDataAsync(int bookingId);
    Task<string> getUserEmailById(int UserId);
}