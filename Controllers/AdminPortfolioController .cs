using DevelopersHubAPI.Data;
using DevelopersHubAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevelopersHubAPI.Controllers;
[Authorize]
[Route("api/admin/[controller]")]
[ApiController]
public class AdminPortfolioController : ControllerBase
{
    private readonly AppDbContext _context;

    public AdminPortfolioController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Portfolio>>> GetAllPortfolio()
    {
        return await _context.Portfolios.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Portfolio>> GetPortfolio(int id)
    {
        var portfolio = await _context.Portfolios.FindAsync(id);
        if (portfolio == null)
            return NotFound();
        return portfolio;
    }

    [HttpPost]
    public async Task<ActionResult<Portfolio>> CreatePortfolio(Portfolio portfolio)
    {
        portfolio.CreatedAt = DateTime.UtcNow;
        portfolio.CreatedBy = "Admin";
        portfolio.LastUpdatedAt = DateTime.UtcNow;
        portfolio.LastUpdatedBy = "Admin";

        _context.Portfolios.Add(portfolio);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPortfolio), new { id = portfolio.Id }, portfolio);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePortfolio(int id, Portfolio portfolio)
    {
        if (id != portfolio.Id)
            return BadRequest();

        portfolio.LastUpdatedAt = DateTime.UtcNow;
        portfolio.LastUpdatedBy = "Admin";

        _context.Entry(portfolio).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePortfolio(int id)
    {
        var portfolio = await _context.Portfolios.FindAsync(id);
        if (portfolio == null)
            return NotFound();

        _context.Portfolios.Remove(portfolio);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}