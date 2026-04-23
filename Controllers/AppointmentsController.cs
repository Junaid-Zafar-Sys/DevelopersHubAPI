using Microsoft.AspNetCore.Mvc;
using DevelopersHubAPI.Data;
using DevelopersHubAPI.Models;

namespace DevelopersHubAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppointmentsController : ControllerBase
{
    private readonly AppDbContext _context;

    public AppointmentsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<Appointment>> CreateAppointment(Appointment appointment)
    {
        appointment.CreatedAt = DateTime.UtcNow;
        _context.Appointments.Add(appointment);
        await _context.SaveChangesAsync();
        return Ok(appointment);
    }
}