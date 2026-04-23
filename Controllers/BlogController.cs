using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DevelopersHubAPI.Data;
using DevelopersHubAPI.Models;

namespace DevelopersHubAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogController : ControllerBase
{
    private readonly AppDbContext _context;

    public BlogController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BlogPost>>> GetBlogPosts()
    {
        return await _context.BlogPosts.ToListAsync();
    }
}