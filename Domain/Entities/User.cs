using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class User : IdentityUser<int>
    {
        /* [Key]
         public int Id { get; set; }
         public string UserName { get; set; } = string.Empty;
         public byte[] PasswordHash { get; set; }
         public byte[] PasswordSalt { get; set; }*/
    }
}
