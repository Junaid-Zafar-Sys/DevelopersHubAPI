using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DevelopersHubAPI.Data;
using DevelopersHubAPI.Models;

namespace DevelopersHubAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InquiriesController : ControllerBase
{
    private readonly AppDbContext _context;

    public InquiriesController(AppDbContext context)
    {
        _context = context;
    }

    // POST: api/inquiries - PUBLIC (Form submit karne ke liye)
    [HttpPost]
    public async Task<ActionResult<Inquiry>> CreateInquiry(Inquiry inquiry)
    {
        inquiry.CreatedAt = DateTime.UtcNow;
        inquiry.LastUpdatedBy = null;  // Public form se null
        _context.Inquiries.Add(inquiry);
        await _context.SaveChangesAsync();
        return Ok(new { message = "Inquiry submitted successfully", id = inquiry.Id });
    }

    // GET: api/inquiries - PROTECTED (Sirf admin dekh sakta hai)
    // TODO: [Authorize] lagana baad mein jab JWT implement hoga
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Inquiry>>> GetAllInquiries()
    {
        var inquiries = await _context.Inquiries
            .OrderByDescending(i => i.CreatedAt)
            .ToListAsync();
        return Ok(inquiries);
    }

    // GET: api/inquiries/{id} - PROTECTED
    [HttpGet("{id}")]
    public async Task<ActionResult<Inquiry>> GetInquiry(int id)
    {
        var inquiry = await _context.Inquiries.FindAsync(id);
        if (inquiry == null)
            return NotFound();
        return Ok(inquiry);
    }

    // PUT: api/inquiries/{id}/read - Mark as read
    [HttpPut("{id}/read")]
    public async Task<IActionResult> MarkAsRead(int id)
    {
        var inquiry = await _context.Inquiries.FindAsync(id);
        if (inquiry == null)
            return NotFound();

        inquiry.IsRead = true;
        inquiry.LastUpdatedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync();

        return Ok(new { message = "Inquiry marked as read" });
    }

    // DELETE: api/inquiries/{id} - PROTECTED
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteInquiry(int id)
    {
        var inquiry = await _context.Inquiries.FindAsync(id);
        if (inquiry == null)
            return NotFound();

        _context.Inquiries.Remove(inquiry);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Inquiry deleted" });
    }
}