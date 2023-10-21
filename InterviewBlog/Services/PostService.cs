using InterviewBlog.Data;
using InterviewBlog.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace InterviewBlog.Services;
public class PostService : IPostService
{
    private readonly ApplicationDbContext _db;

    public PostService(ApplicationDbContext db)
    {
        _db = db;
    }
    public async Task<List<Post>> Add(Post post)
    {
        await _db.Posts.AddAsync(post);
        await _db.SaveChangesAsync();
        return await _db.Posts.ToListAsync();
    }

    public async Task<Post> GetPost(int id)
    {
        var postObj =  await _db.Posts.FindAsync(id);
        if (postObj == null)
        {
            return null;
        }
        return postObj;
    }

    public async Task<List<Post>> GetAllPosts()
    {
        List<Post> postObjs = await _db.Posts.ToListAsync();
        return postObjs;
    }

    public async Task<List<Comment>> AddComment(Comment comment)
    {
         await _db.Comments.AddAsync(comment);
         await _db.SaveChangesAsync();
         return await _db.Comments.ToListAsync();
    }

    public async Task<List<Comment>> GetPostComment(int postId)
    {
        List<Comment> comments = await _db.Comments.Where(c => c.PostId == postId).ToListAsync();
        return comments;
    }
}