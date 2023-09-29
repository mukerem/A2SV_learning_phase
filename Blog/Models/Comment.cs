using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;


public class Comment
{
    public int CommentId { get; set; }
    public int PostId { get; set; }
    public string Text { get; set; }
    public DateTime CreatedAt { get; set; }
    public Post Post { get; set; }
}
