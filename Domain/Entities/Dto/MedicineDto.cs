namespace Domain.Entities;

public class MedicineDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public ProducerDto Producer { get; set; }
    public string Body { get; set; }
    public List<DoseDto> Doses { get; set; }
    public bool NeedPrescription { get; set; }
}