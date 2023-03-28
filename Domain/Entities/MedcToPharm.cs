using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities
{
    public class MedcToPharm
    {
        [Key]
        public int Id { get; set; }
        public int PharmId { get; set; }
        public Pharmacy Pharmacy { get; set; }
        public int MedcId { get; set; }
        public Medicine Medicine { get; set; }
        public int DoseId { get; set; }
        public Dose Doses { get; set; }
        [Required]
        [Precision(18, 2)]
        public decimal Price { get; set; }
        public int Amount { get; set; }
    }
}
