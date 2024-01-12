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

    // Other methods...

    public List<Comment> GetCommentsByUserId(string userId)
    {
        return _db.Comments.Where(c => c.UserID == userId).ToList();
    }
}
