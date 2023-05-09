namespace Domain.Entities;

public class PharmacyDto
{
    public int pharmId { get; set; }
    public string pharmacyName { get; set; } = string.Empty;
    public string address { get; set; } = string.Empty;
    public string workingHours { get; set; } = string.Empty;
    public string phoneNumber { get; set; } = string.Empty;
}