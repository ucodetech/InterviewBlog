using InterviewBlog.Models;
using InterviewBlog.Services;
using Microsoft.AspNetCore.Mvc;

namespace InterviewBlog.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PostController : Controller
{
    private readonly IPostService _postService;
    public PostController(IPostService postService)
    {
        _postService = postService;
    }
    
    [HttpGet("Posts")]
    public async Task<ActionResult<List<Post>>> GetPosts()
    {
        return await _postService.GetAllPosts();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Post>> GetPost(int id)
    {
        var post = await _postService.GetPost(id);
        var comments = await _postService.GetPostComment(id);
        if (post is null)
        {
            return NotFound("Sorry no post with that id passed!");
        }

        var response = new
        {
            Post = post,
            Comments = comments
        };
        return CreatedAtAction(nameof(GetPost), new {id}, response);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<List<Post>>> CreatePost(Post post)
    {
        if (!ModelState.IsValid)
        {
            return NotFound("Error Adding post");
        }
        var result = await _postService.Add(post);
        var response = new
        {
            Message = "Post created Successfully!",
            
        };

        return CreatedAtAction(nameof(GetPosts), response);
    }

    [HttpPost("{postId}/comments")]
    public async Task<ActionResult<List<Comment>>> AddComment(int postId, Comment comment)
    {
        if (!ModelState.IsValid)
        {
            return NotFound("Comment can not be empty");
        }

        var post = await _postService.GetPost(postId);
        if (post is null)
        {
            return NotFound("Post not found!");
        }

        comment.PostId = postId;
        await _postService.AddComment(comment);
        var response = new
        {
            message = "Comment added successfully!",
            
        };
        return Ok(response);
    }
    
    [HttpGet("{postId}/get/comments")]
    public async Task<ActionResult<Post>> GetPostComment(int postId)
    {
        List<Comment> comments = await _postService.GetPostComment(postId);
        if (comments is null)
        {
            return NotFound("Sorry no comment found!");
        }

        return Ok(comments);
    }

}