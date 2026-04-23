using System;
using System.ComponentModel.DataAnnotations;

namespace DevelopersHubAPI.Models
{
    public class AdminUser
    {
        public int Id { get; set; }

        [Required, MaxLength(50), MinLength(3)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [MaxLength(200)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Role { get; set; } = "Admin";

        public bool IsActive { get; set; } = true;

        public DateTime? LastLoginAt { get; set; }

        [MaxLength(50)]
        public string? LastLoginIp { get; set; }

        [MaxLength(500)]
        public string? ResetToken { get; set; }

        public DateTime? ResetTokenExpiresAt { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [MaxLength(100)]
        public string CreatedBy { get; set; } = string.Empty;

        public DateTime LastUpdatedAt { get; set; } = DateTime.UtcNow;

        [MaxLength(100)]
        public string LastUpdatedBy { get; set; }


    }
}
