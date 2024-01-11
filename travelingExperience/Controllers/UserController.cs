using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using travelingExperience.Models;
using Scrypt;
using travelingExperience.Repository;
using travelingExperience.Entity;
using travelingExperience.DbConnetion;
using Microsoft.AspNetCore.Identity;
using travelingExperience.Data;
using travelingExperience.Data.Services;


namespace travelingExperience.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _db;
        private readonly ScryptEncoder encoder;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _singInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ITravelsService _travelsService;

        public UserController(AppDbContext db,UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> singInManager, RoleManager<IdentityRole> roleManager,   ITravelsService travelsService)
        {
            encoder = new ScryptEncoder();
            _singInManager = singInManager;
            _roleManager = roleManager;
            _db = db;
            _userManager = userManager;
            _travelsService = travelsService;
        }
        [HttpGet]
         public async Task<IActionResult> UserTravels ()
        {
            var userId = _userManager.GetUserId(User);
            var userTravels = await _travelsService.GetTravelsByUserIdAsync(userId);

            return View(userTravels);
        }
        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound(); // Handle case where user is not found
            }

            return View(user); // Pass the user object to the view
        }
       
        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }
        public IActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> Register()
        {
            if (!_roleManager.RoleExistsAsync(Helper.Admin).GetAwaiter().GetResult())
            {
                await _roleManager.RoleExistsAsync(Helper.Admin);
                await _roleManager.RoleExistsAsync(Helper.User);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _singInManager.PasswordSignInAsync(model.UserName, model.Password,model.RememberMe,false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid Login attempt!");
            }
            return View(model);
        }
       
        [HttpPost] 
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Register(RegisterModel model)
        {

          
           
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    Name = model.Name,
                    SName = model.SName,
                    Number = model.Number,
                    Age = model.Age
                };
               var result = await _userManager.CreateAsync(user,model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, model.RoleName);
                    await _singInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index","Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
          return View(model);
        }
       
        [HttpPost]
        public async Task<IActionResult> Logoff()
        {
            await _singInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
