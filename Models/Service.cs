using System;
using System.ComponentModel.DataAnnotations;

namespace DevelopersHubAPI.Models;

public class Service
{
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;
    [Required]

    public string Description { get; set; } = string.Empty ;

    public string? Icon { get; set; } 

    public bool IsActive { get; set; }=true;

    public int DisplayOrder {  get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [MaxLength(100)]
    public string CreatedBy { get; set; } = string.Empty;

    public DateTime LastUpdatedAt { get; set;} = DateTime.UtcNow;

    [MaxLength(100)]
    public string LastUpdatedBy { get; set;} 

}
