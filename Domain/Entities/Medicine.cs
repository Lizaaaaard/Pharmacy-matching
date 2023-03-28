using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Medicine
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public bool IsPrescription { get; set; }

        public string ProducerCountry { get; set; } = string.Empty;
        
        public string ProducerCompanyName { get; set; } = string.Empty;
        

        public List<Pharmacy> Pharmacies { get; set; } = new List<Pharmacy>();
        
        public List<MedcToPharm> MedcToPharms { get; set; } = new List<MedcToPharm>();


    }
}
