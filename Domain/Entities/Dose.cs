using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

public class Dose
{
    [Key]
    public int Id { get; set; }
    public string Package { get; set; }
    public string ReleaseForm { get; set; } = string.Empty;
    public List<MedcToPharm> MedcToPharms { get; set; } = new List<MedcToPharm>();
}