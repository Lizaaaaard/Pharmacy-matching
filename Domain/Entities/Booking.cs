using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Booking
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int UserId { get; set; }
    [Required]
    public int CartId { get; set; }
    [Required]
    public DateTime BookingDate { get; set; } = DateTime.Now;
    [Required]
    public string Status { get; set; } = String.Empty;
    public string Notes { get; set; } = String.Empty;
    public List<Cart> Carts { get; set; } = new List<Cart>();
}