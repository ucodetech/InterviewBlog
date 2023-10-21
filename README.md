# InterviewBlog
Question: Create Endpoints for Posts and Comments
You are working on a blog application using ASP.NET Core Web API. Your task is to implement
the API endpoints for creating a post and adding comments to a post.
1. Create Post Endpoint:
Write a controller action to handle the creation of a new post. The action should accept a POST
request with the post data (e.g., title, content) and save it to a database or some storage.
[HttpPost]
public IActionResult CreatePost([FromBody] PostDto postDto)
{
// Your implementation to create a new post
// Save the post to the database or storage
// Return appropriate response based on success or failure
// Ensure proper error handling and validation
}
2. Create Comment Endpoint:
Write a controller action to handle adding a comment to an existing post. The action should
accept a POST request with the comment data (e.g., content, post ID) and add it to the
appropriate post.
[HttpPost("{postId}/comments")]
public IActionResult AddComment(int postId, [FromBody] CommentDto commentDto)
{
// Your implementation to add a comment to the post with the specified postId
// Save the comment to the database or storage
// Return appropriate response based on success or failure
// Ensure proper error handling and validation
}
You are expected to implement these actions in an appropriate controller, handle input
validation, error cases, and save data to a storage mechanism (e.g., in-memory storage or a
database). Additionally, you should handle any potential exceptions and provide meaningful
responses.
Feel free to include any necessary DTOs (Data Transfer Objects) for post and comment
representation. Ensure that the endpoints are RESTful and follow best practices for API design.
