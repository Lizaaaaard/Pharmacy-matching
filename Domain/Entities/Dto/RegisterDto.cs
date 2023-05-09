using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class RegisterDto
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string UserName { get; set; } = string.Empty;
    [Required]
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public DateTime RegDate { get; set; } = DateTime.Now;
    public string Password { get; set; } = string.Empty;
}