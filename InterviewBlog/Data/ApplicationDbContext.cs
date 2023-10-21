using InterviewBlog.Models;
using Microsoft.EntityFrameworkCore;

namespace InterviewBlog.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }
    
}