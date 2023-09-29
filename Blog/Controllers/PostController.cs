using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// namespace Blog.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostController : ControllerBase
{
  private readonly BlogContext _context;

  public PostController(BlogContext context)
  {
    _context = context;
  }

  // GET: api/posts
  [HttpGet]
  public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
  {
    return await _context.Posts.ToListAsync();
  }

  // GET: api/posts/5
  [HttpGet("{id}")]
  public async Task<ActionResult<Post>> GetPost(int id)
  {
    var post = await _context.Posts.FindAsync(id);

    if (post == null)
    {
      return NotFound();
    }

    return post;
  }

  // POST api/posts
  [HttpPost]
  public async Task<ActionResult<Post>> PostPost(Post post)
  {
    _context.Posts.Add(post);
    await _context.SaveChangesAsync();

    return CreatedAtAction(nameof(GetPost), new { id = post.PostId }, post);
  }

  // PUT api/posts/5
  [HttpPut("{id}")]
  public async Task<IActionResult> PutPost(int id, Post post)
  {
    if (id != post.PostId)
    {
      return BadRequest();
    }

    _context.Entry(post).State = EntityState.Modified;
    await _context.SaveChangesAsync();

    return Ok(await _context.Posts.FindAsync(id));

  }

  // DELETE api/posts/5
  [HttpDelete("{id}")]
  public async Task<IActionResult> DeletePost(int id)
  {
    var post = await _context.Posts.FindAsync(id);

    if (post == null)
    {
      return NotFound();
    }

    _context.Posts.Remove(post);
    await _context.SaveChangesAsync();

    return Ok(post);
  }
}