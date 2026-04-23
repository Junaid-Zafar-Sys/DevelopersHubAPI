using System;
using Microsoft.EntityFrameworkCore;
using DevelopersHubAPI.Models;

namespace DevelopersHubAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        public DbSet<Service> Services { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Inquiry> Inquiries { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AdminUser>()
                .HasIndex(a => a.Username)
                .IsUnique();

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword("Admin@123");

            modelBuilder.Entity<AdminUser>().HasData(
            new AdminUser
            {
                Id = 1,                          // Primary key value
                Username = "admin",              // Login username
                Email = "admin@developershub.com", // Admin email address
                PasswordHash = hashedPassword,    // Hashed password (not plain text!)
                Role = "SuperAdmin",              // Highest role with all permissions
                IsActive = true,                 // Account is active/enabled
                CreatedAt = DateTime.UtcNow,     // Current UTC time when created
                CreatedBy = "System",            // Created by system (not a user)
                LastUpdatedAt = DateTime.UtcNow,  // Initial update time
                LastUpdatedBy = "System"
            }
        );
            // Admin can later add/edit/delete these from dashboard
            modelBuilder.Entity<Service>().HasData(
                // Service 1: Web Development
                new Service { Id = 1,
                    Title = "Web Development",
                    Description = "Custom web applications", 
                    Icon = "fa-code",
                    DisplayOrder = 1,
                    IsActive = true, 
                    CreatedAt = DateTime.UtcNow, 
                    CreatedBy = "System",
                    LastUpdatedAt = DateTime.UtcNow ,
                    LastUpdatedBy = "System"
                },

                // Service 2: Mobile App Development
                new Service { Id = 2, 
                    Title = "Mobile App Development", 
                    Description = "iOS and Android apps",
                    Icon = "fa-mobile-alt", 
                    DisplayOrder = 2,
                    IsActive = true, 
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "System", 
                    LastUpdatedAt = DateTime.UtcNow ,
                    LastUpdatedBy = "System"
                },

                // Service 3: Cloud Solutions
                new Service {
                    Id = 3,
                    Title = "Cloud Solutions", 
                    Description = "AWS, Azure, GCP", 
                    Icon = "fa-cloud",
                    DisplayOrder = 3, 
                    IsActive = true, 
                    CreatedAt = DateTime.UtcNow, 
                    CreatedBy = "System", 
                    LastUpdatedAt = DateTime.UtcNow,
                    LastUpdatedBy = "System"
                },

                // Service 4: UI/UX Design
                new Service {
                    Id = 4, 
                    Title = "UI/UX Design", 
                    Description = "Beautiful interfaces",
                    Icon = "fa-paintbrush", 
                    DisplayOrder = 4, 
                    IsActive = true, 
                    CreatedAt = DateTime.UtcNow, 
                    CreatedBy = "System", 
                    LastUpdatedAt = DateTime.UtcNow ,
                    LastUpdatedBy = "System"
                }
            );

             //Insert example projects shown on portfolio page
            modelBuilder.Entity<Portfolio>().HasData(
                // Portfolio item 1: E-Commerce Platform
                new Portfolio { 
                    Id = 1, 
                    Title = "E-Commerce Platform",
                    Description = "Online store with payment integration",
                    ClientName = "TechShop Inc.", 
                    DisplayOrder = 1, 
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow, 
                    CreatedBy = "System", 
                    LastUpdatedAt = DateTime.UtcNow ,
                    LastUpdatedBy = "System"
                },

                // Portfolio item 2: Healthcare Management System
                new Portfolio { 
                    Id = 2,
                    Title = "Healthcare Management System", 
                    Description = "Patient records system",
                    ClientName = "MediCare Hospital",
                    DisplayOrder = 2,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow, 
                    CreatedBy = "System", 
                    LastUpdatedAt = DateTime.UtcNow ,
                    LastUpdatedBy = "System"
                }
            );
        }
    }
}
