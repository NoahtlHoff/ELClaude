using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace equilog_backend.DTOs.SecurityDTOs
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
