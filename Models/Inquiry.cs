using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace DevelopersHubAPI.Models
{
    public class Inquiry
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required, MaxLength(200), EmailAddress]
        public string Email { get; set; }= string.Empty;

        [MaxLength(50), Phone]
        public string? Phone { get; set; }

        [Required]
        public string Message {  get; set; }=string.Empty;

        [MaxLength(200)]
        public string? Service { get; set; }

        public bool IsRead { get; set; } = false;

        [MaxLength(50)]
        public string? ResponseStatus { get; set; }

        public string? AdminResponse { get; set; }

        [MaxLength(100)]
        public string? RespondedBy { get; set; }

        public DateTime? RespondedAt { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [MaxLength(100)]
        public string CreatedBy { get; set; } = string.Empty;

        public DateTime LastUpdatedAt { get; set; } = DateTime.UtcNow;

        [MaxLength(100)]
        public string LastUpdatedBy { get; set; }


    }
}
