using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DevelopersHubAPI.Data;
using DevelopersHubAPI.Models;

namespace DevelopersHubAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServicesController : ControllerBase
{
    private readonly AppDbContext _context;

    public ServicesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Service>>> GetServices()
    {
        return await _context.Services.ToListAsync();
    }
}