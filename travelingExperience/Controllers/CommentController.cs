using Microsoft.AspNetCore.Mvc;
using travelingExperience.Data.Services;
using travelingExperience.Models;
using System.Collections.Generic;

namespace travelingExperience.Controllers
{
    public class CommentController : Controller
    {
        private readonly CommentService _commentService;

        public CommentController(CommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            // Retrieve all comments
            List<Comment> comments = _commentService.GetAllComments();

            // Pass the comments to the view
            return View(comments);
        }

        public IActionResult AddComment(Comment model)
        {
            // Validate and add the comment
            // ...

            return RedirectToAction("ProfileView", "User", new { id = model.UserID });
        }
    }
}
