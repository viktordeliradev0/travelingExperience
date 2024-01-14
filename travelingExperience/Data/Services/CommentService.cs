using Microsoft.EntityFrameworkCore;
using travelingExperience.DbConnetion;
using travelingExperience.Models;

namespace travelingExperience.Data.Services;
public class CommentService
{
    private readonly AppDbContext _db;

    public CommentService(AppDbContext db)
    {
        _db = db;
    }

    public List<Comment> GetAllComments()
    {
        
        return _db.Comments.ToList();
    }
    public async Task AddCommentAsync(string userId, string commentText)
    {
        try
        {
            // Fetch the user by id
            var user = await _db.Users.FindAsync(userId);

            if (user == null)
            {
               
                throw new InvalidOperationException("User not found");
            }

            // Create a new comment
            var newComment = new Comment
            {
                UserID = userId,
                CommentText = commentText,
                CommentDate = DateTime.Now.Date,
                
            };

            // Add the comment to the user's comments
            user.Comments.Add(newComment);

            // Save changes to the database
            await _db.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            // Handle exceptions appropriately
            Console.WriteLine($"Error adding comment: {ex.Message}");
            throw;
        }
    }
    
    public async Task SaveChangesAsync()
    {
        await _db.SaveChangesAsync();
    }

    public List<Comment> GetCommentsByUserId(string userId)
    {
        return _db.Comments.Where(c => c.UserID == userId).ToList();
    }
}
