namespace Domain.Entities;

public class NewUserRoleDto
{
    public int UserId { get; set; }
    public string Role { get; set; } = string.Empty;
    public int PharmId { get; set; }
}