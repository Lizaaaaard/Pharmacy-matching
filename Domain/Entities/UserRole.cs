using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class UserRole : IdentityUserRole<int>
{
    [DataType(DataType.Date)]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
    public DateTime AssignDate { get; set; } = DateTime.Now;
    public int? PharmId { get; set; }
    public Pharmacy Pharmacy { get; set; }
}