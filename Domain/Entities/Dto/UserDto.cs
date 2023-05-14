using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class UserDto
{
    [Key]
    public int Id { get; set; }
    public string Login { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
}