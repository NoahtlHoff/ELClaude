using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace equilog_backend.Models.Security
{
    public class AuthUser
    {
        [Key]
        public  int Id { get; set; }

        public required string Email { get; set; }

        public required byte[] PasswordHash { get; set; }

        public required byte[] PasswordSalt { get; set; }

        [ForeignKey("User")]
        public required int UserIdFk { get; set; }
        public virtual User? User { get; set; }
    }
}
