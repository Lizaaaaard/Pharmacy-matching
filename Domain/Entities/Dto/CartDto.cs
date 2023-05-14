using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

public class CartDto
{
    [Key]
    public int Id { get; set; }
    public int PharmId { get; set; }
    public int UserId { get; set; }
    public List<CartMedcWithDosesDto> MedcList { get; set; }
    [Precision(18, 2)]
    public decimal Price { get; set; }
}