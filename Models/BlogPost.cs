using System;
using System.ComponentModel.DataAnnotations;
namespace DevelopersHubAPI.Models
{
    public class BlogPost
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Content { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Excerpt { get; set; }

        [MaxLength(500)]
        public string? FeaturedImageUrl { get; set; }

        [Required, MaxLength(100)]
        public string Author { get; set; } = "Admin";

        [MaxLength(100)]
        public string? Category { get; set; }

        public bool IsPublished { get; set; } = false;

        public DateTime? PublishedDate { get; set; }

        public int ViewCount { get; set; } = 0;

        [MaxLength(500)]
        public string? Tags { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [MaxLength(100)]
        public string CreatedBy { get; set; } = string.Empty;

        public DateTime LastUpdatedAt { get; set; } = DateTime.UtcNow;

        [MaxLength(100)]
        public string LastUpdatedBy { get; set; }


    }
}
