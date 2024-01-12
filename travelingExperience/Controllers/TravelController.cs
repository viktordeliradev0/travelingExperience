using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using travelingExperience.Data.Services;
using travelingExperience.Entity;
using travelingExperience.Models;

namespace sharedTravel.Controllers
{
    public class TravelController : Controller
    {

        private readonly ITravelsService _service;
        private readonly UserManager<ApplicationUser> _userManager;

        public TravelController(ITravelsService service, UserManager<ApplicationUser> userManager)
        {
            _service = service;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        public async Task<IActionResult> Index1()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }
        public ApplicationUser GetUserById(string userId)
        {
            return _userManager.FindByIdAsync(userId).Result;
        }

        public async Task<IActionResult> Info(int id)
        {
            var TravelDetails = await _service.GetByIdAsync(id);
            if (TravelDetails == null) return View("Not Found");
            TravelDetails.User = GetUserById(TravelDetails.UserID);
            return View(TravelDetails);

        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create([Bind("UserID,StartDestination,EndDestination,Descrition,StartDate,EndDate,Price,Seats")] Travel travel)
        {
            if (!ModelState.IsValid)
            {
              
                   await  _service.AddAsync(travel);
                return RedirectToAction("Index");

            }
            return View(travel);

        }

        public async Task<IActionResult> Details(int id)
        {
            var TravelDetails = await _service.GetByIdAsync(id);
            if (TravelDetails == null) return View("Not Found");
            return View(TravelDetails);

        }
        public async Task<IActionResult> Edit(int id)
        {
            var TravelDetails = await _service.GetByIdAsync(id);
            if (TravelDetails == null) return View("Not Found");
            return View(TravelDetails);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, Travel travel)
        {
            travel.Id = 0;
            if (!ModelState.IsValid)
            {
                await _service.UpdateAsync(id, travel);
                await _service.DeleteAsync(id);
                return RedirectToAction("Index");
            }
           
            return View(travel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var TravelDetails = await _service.GetByIdAsync(id);
            if (TravelDetails == null) return View("Not Found");
            return View(TravelDetails);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var travelDetails = await _service.GetByIdAsync(id);

            if (travelDetails == null) return View("Not Found");

            await _service.DeleteAsync(id);

            return RedirectToAction("Index");
        }
    }
}
