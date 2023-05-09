using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Order
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int MedcToPharmId { get; set; }
    [Required]
    public int Amount { get; set; }
    public MedcToPharm MedcToPharm { get; set; }
    public List<Cart> Carts { get; set; } = new List<Cart>();
}