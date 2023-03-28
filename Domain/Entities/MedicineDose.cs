using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

public class MedicineDose
{
    public int medId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Company { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public int dId { get; set; }
    public string Package { get; set; } = string.Empty;
    [Precision(18, 2)]
    public decimal minPrice { get; set; }
    [Precision(18, 2)]
    public decimal maxPrice { get; set; }
    public int Availability { get; set; }
    public bool needPrescription { get; set; }
}