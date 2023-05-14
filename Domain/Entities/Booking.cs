using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

public class Booking
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int UserId { get; set; }
    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime BookingDate { get; set; } = DateTime.Now;
    [Required]
    public string Status { get; set; } = String.Empty;
    [Required]
    [Precision(18, 2)]
    public decimal TotalPrice { get; set; }
    public string Notes { get; set; } = String.Empty;
    public List<Order> Orders { get; set; } = new List<Order>();
}