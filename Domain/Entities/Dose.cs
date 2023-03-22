using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

public class Dose
{
    [Key]
    public int Id { get; set; }
    public string Package { get; set; }
    [Required]
    [Precision(18, 2)]
    public decimal Price { get; set; }
    public int Amount { get; set; }
    public List<MedcToPharm> MedcToPharms { get; set; } = new List<MedcToPharm>();
}