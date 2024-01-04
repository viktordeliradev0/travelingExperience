using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using travelingExperience.Models;
using Scrypt;
using travelingExperience.Repository;
using travelingExperience.Entity;


namespace travelingExperience.Controllers
{
    public class UserController : Controller
    {
        private ScryptEncoder encoder;
        private UserRepository userRepository;
        private CrudRepository<User> crudRepository;
        public UserController()
        {
            encoder = new ScryptEncoder();
            userRepository = new UserRepository();
            crudRepository = new CrudRepository<User>();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            User user = userRepository.FindByUsernameAndPassword(model.UserName, model.Password);
            if (user == null)
            {
                return View(model);
            }
            else
            {
                List<Claim> claims = new List<Claim>() {
                    new Claim(ClaimTypes.NameIdentifier , $"{user.Id}"),
                    new Claim(ClaimTypes.Email , user.Email),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Role , "User"),
                    new Claim(ClaimTypes.Sid , user.Id.ToString())
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                CookieAuthenticationDefaults.AuthenticationScheme);

                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    IsPersistent = model.RememberMe
                };

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), properties);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
          

            model.Password = encoder.Encode(model.Password);

            crudRepository.Insert(new User(model.Name, model.SName, model.UserName,model.Email,model.Password,model.Number,model.Age));

            return RedirectToAction("Login", new { model = model });
        }
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }
    }
}
