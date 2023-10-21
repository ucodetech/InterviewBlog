using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterviewBlog.Models;

public class Comment
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(1000, ErrorMessage = "Comment can not be more than 1000 characters long")]
    public required string Content { get; set; }
    public int PostId { get; set; }
    // [ForeignKey("PostId")]
    // public Post Post { get; set; }
}