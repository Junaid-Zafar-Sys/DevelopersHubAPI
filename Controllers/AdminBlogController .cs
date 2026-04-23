using DevelopersHubAPI.Data;
using DevelopersHubAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevelopersHubAPI.Controllers;
[Authorize]
[Route("api/admin/[controller]")]
[ApiController]
public class AdminBlogController : ControllerBase
{
    private readonly AppDbContext _context;

    public AdminBlogController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BlogPost>>> GetAllBlogPosts()
    {
        return await _context.BlogPosts.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BlogPost>> GetBlogPost(int id)
    {
        var blog = await _context.BlogPosts.FindAsync(id);
        if (blog == null)
            return NotFound();
        return blog;
    }

    [HttpPost]
    public async Task<ActionResult<BlogPost>> CreateBlogPost(BlogPost blogPost)
    {
        blogPost.CreatedAt = DateTime.UtcNow;
        blogPost.CreatedBy = "Admin";
        blogPost.LastUpdatedAt = DateTime.UtcNow;
        blogPost.LastUpdatedBy = "Admin";

        _context.BlogPosts.Add(blogPost);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetBlogPost), new { id = blogPost.Id }, blogPost);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBlogPost(int id, BlogPost blogPost)
    {
        if (id != blogPost.Id)
            return BadRequest();

        blogPost.LastUpdatedAt = DateTime.UtcNow;
        blogPost.LastUpdatedBy = "Admin";

        _context.Entry(blogPost).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBlogPost(int id)
    {
        var blog = await _context.BlogPosts.FindAsync(id);
        if (blog == null)
            return NotFound();

        _context.BlogPosts.Remove(blog);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}