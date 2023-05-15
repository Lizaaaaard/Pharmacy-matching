using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

public class HistoryDto
{
    public int OrderId { get; set; }
    public int UserId { get; set; }
    public DateTime OrderDate { get; set; }
    public string PharmacyTitle { get; set; } = string.Empty;
    public List<MedInCartDto> MedcList { get; set; } = new List<MedInCartDto>();
    public string Status { get; set; }
    [Precision(18, 2)]
    public decimal TotalPrice { get; set; }
}