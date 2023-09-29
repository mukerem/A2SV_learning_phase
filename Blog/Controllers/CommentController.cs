using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// namespace Blog.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentController : ControllerBase
{
  private readonly BlogContext _context;

  public CommentController(BlogContext context)
  {
    _context = context;
  }

  // GET: api/comments
  [HttpGet]
  public async Task<ActionResult<IEnumerable<Comment>>> GetComments()
  {
    return await _context.Comments.ToListAsync();
  }

  // GET: api/comments/5
  [HttpGet("{id}")]
  public async Task<ActionResult<Comment>> GetComment(int id)
  {
    var comment = await _context.Comments.FindAsync(id);

    if (comment == null)
    {
      return NotFound();
    }

    return comment;
  }

  // POST api/comments
  [HttpPost]
  public async Task<ActionResult<Comment>> PostComment(Comment comment)
  {
    _context.Comments.Add(comment);
    await _context.SaveChangesAsync();

    return CreatedAtAction(nameof(GetComment), new { id = comment.CommentId }, comment);
  }

  // PUT api/comments/5
  [HttpPut("{id}")]
  public async Task<IActionResult> PutComment(int id, Comment comment)
  {
    if (id != comment.CommentId)
    {
      return BadRequest();
    }

    _context.Entry(comment).State = EntityState.Modified;
    await _context.SaveChangesAsync();

    return Ok(await _context.Comments.FindAsync(id));

  }

  // DELETE api/comments/5
  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteComment(int id)
  {
    var comment = await _context.Comments.FindAsync(id);

    if (comment == null)
    {
      return NotFound();
    }

    _context.Comments.Remove(comment);
    await _context.SaveChangesAsync();

    return Ok(comment);
  }
}