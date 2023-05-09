using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Cart
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int OrderId { get; set; }
    [Required]
    public int BookingId { get; set; }
    public Order Order { get; set; }
    public Booking Booking { get; set; }
}