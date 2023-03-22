using System.ComponentModel.DataAnnotations;

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
    }
}
