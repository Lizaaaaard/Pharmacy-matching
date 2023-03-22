using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

public class DoseDto
{
    public int Id { get; set; }
    public string Package { get; set; }
    [Precision(18, 2)]
    public decimal MinPrice { get; set; }
    [Precision(18, 2)]
    public decimal MaxPrice { get; set; }
    public int Availability { get; set; }
}