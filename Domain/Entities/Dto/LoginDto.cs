using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class LoginDto
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
