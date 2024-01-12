using Microsoft.AspNetCore.Mvc;
using travelingExperience.Models;

namespace travelingExperience.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddComment(Comment model)
        {
            // Validate and add the comment
            // ...

            return RedirectToAction("ProfileView", "User", new { id = model.UserID });
        }
    }
}
