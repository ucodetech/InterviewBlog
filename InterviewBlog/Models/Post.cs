using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace InterviewBlog.Models;

public class Post
{
    [Key]
    public int Id { get; set; }
    [Required]
    public required string Title { get; set; }
    [Required]
    public required string Content { get; set; }
    [ValidateNever]
    public DateTime DateCreated { get; set; }
   
    // public List<Comment>? Comments { get; set; }
}