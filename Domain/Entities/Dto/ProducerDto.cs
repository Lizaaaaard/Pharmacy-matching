namespace Domain.Entities;

public class ProducerDto
{
    public ProducerDto(string producerCompanyName, string producerCountry)
    {
        Company = producerCompanyName;
        Country = producerCountry;
    }

    public string Company { get; set; }
    public string Country { get; set; }
}