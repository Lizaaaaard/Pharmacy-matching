using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Pharmacy
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        public List<Medicine> Medicines { get; set; } = new List<Medicine>();
        public List<MedcToPharm> MedcToPharms { get; set; } = new List<MedcToPharm>();
    }
}
