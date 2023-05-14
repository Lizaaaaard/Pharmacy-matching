using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

public class MedInCartDto
{
   public string medcTitle { get; set; } = string.Empty;
   public string package { get; set; } = string.Empty;
   public int amount { get; set; }
   [Precision(18, 2)]
   public decimal price { get; set; }
}