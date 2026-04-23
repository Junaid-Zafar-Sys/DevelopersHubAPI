using System;
using System.ComponentModel.DataAnnotations;

namespace DevelopersHubAPI.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required, MaxLength(200), EmailAddress]
        public string Email { get; set; } = string.Empty;

        [MaxLength(50), Phone]
        public string? Phone { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        [MaxLength(200)]
        public string? ServiceType {  get; set; }

        [MaxLength(500)]
        public string? Message { get; set; }

        [MaxLength(50)]
        public string Status { get; set; } = "Pending";

        [MaxLength(500)]
        public string? CancellationReason { get; set; }

        [MaxLength(500)]
        public string? MeetingLink { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [MaxLength(100)]
        public string CreatedBy { get; set; } = string.Empty;

        public DateTime LastUpdatedAt { get; set; } = DateTime.UtcNow;

        [MaxLength(100)]
        public string LastUpdatedBy { get; set; }
    }
}
