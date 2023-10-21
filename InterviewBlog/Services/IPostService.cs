using InterviewBlog.Models;

namespace InterviewBlog.Services;

public interface IPostService
{
    Task<List<Post>> Add(Post post);
    Task<Post> GetPost(int id);
    Task<List<Post>> GetAllPosts();

    Task<List<Comment>> AddComment(Comment comment);
    Task<List<Comment>> GetPostComment(int postId);
    
}