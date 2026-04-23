# DevelopersHub API

Complete backend API for agency management system.

## Features
- JWT Authentication
- CRUD operations for Services, Portfolio, Blog
- Client inquiry system
- Appointment booking system
- Swagger documentation

## Tech Stack
- ASP.NET Core 8
- Entity Framework Core
- SQL Server
- JWT Authentication

## Admin Credentials
- Username: admin
- Password: Admin@123

## Setup Instructions
1. Clone repository
2. Update connection string in appsettings.json
3. Run: `dotnet ef database update`
4. Run: `dotnet run`
5. Access Swagger: `https://localhost:5001/swagger`

## API Endpoints

### Public Endpoints
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | /api/Services | Get all services |
| GET | /api/Portfolio | Get portfolio items |
| GET | /api/Blog | Get blog posts |
| POST | /api/Inquiries | Submit contact form |
| POST | /api/Appointments | Book appointment |

### Admin Endpoints (JWT Required)
| Method | Endpoint | Description |
|--------|----------|-------------|
| CRUD | /api/admin/Services | Manage services |
| CRUD | /api/admin/Portfolio | Manage portfolio |
| CRUD | /api/admin/Blog | Manage blog posts |

## GitHub Repository
https://github.com/Junaid-Zafar-Sys/DevelopersHubAPI
