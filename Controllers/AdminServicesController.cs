using DevelopersHubAPI.Data;
using DevelopersHubAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevelopersHubAPI.Controllers;
[Authorize]
[Route("api/admin/[controller]")]
[ApiController]
public class AdminServicesController : ControllerBase
{
    private readonly AppDbContext _context;

    public AdminServicesController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/admin/services - Sab services dekho
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Service>>> GetAllServices()
    {
        return await _context.Services.ToListAsync();
    }

    // GET: api/admin/services/5 - Ek service dekho
    [HttpGet("{id}")]
    public async Task<ActionResult<Service>> GetService(int id)
    {
        var service = await _context.Services.FindAsync(id);
        if (service == null)
            return NotFound();
        return service;
    }

    // POST: api/admin/services - Nayi service banao
    [HttpPost]
    public async Task<ActionResult<Service>> CreateService(Service service)
    {
        service.CreatedAt = DateTime.UtcNow;
        service.CreatedBy = "Admin";
        service.LastUpdatedAt = DateTime.UtcNow;
        service.LastUpdatedBy = "Admin";

        _context.Services.Add(service);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetService), new { id = service.Id }, service);
    }

    // PUT: api/admin/services/5 - Service update karo
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateService(int id, Service service)
    {
        if (id != service.Id)
            return BadRequest();

        service.LastUpdatedAt = DateTime.UtcNow;
        service.LastUpdatedBy = "Admin";

        _context.Entry(service).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ServiceExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // DELETE: api/admin/services/5 - Service delete karo
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteService(int id)
    {
        var service = await _context.Services.FindAsync(id);
        if (service == null)
            return NotFound();

        _context.Services.Remove(service);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ServiceExists(int id)
    {
        return _context.Services.Any(e => e.Id == id);
    }
}