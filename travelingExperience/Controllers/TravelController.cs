using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using travelingExperience.Data.Enums;
using travelingExperience.Data.Services;
using travelingExperience.DbConnetion;
using travelingExperience.Entity;
using travelingExperience.Models;

namespace sharedTravel.Controllers
{
    public class TravelController : Controller
    {

        private readonly ITravelsService _service;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppDbContext _db;
        private readonly ReservationService _reservationService;

        public TravelController(ITravelsService service, UserManager<ApplicationUser> userManager, AppDbContext db,ReservationService reservationService)
        {
            _service = service;
            _userManager = userManager;
            _db = db;
            _reservationService = reservationService;
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
        public async Task<IActionResult> Create([Bind("UserID,StartDestination,EndDestination,Descrition,StartDate,EndDate,Price,Seats,TravelPic")] Travel travel)
        {
            if (!ModelState.IsValid)
            {
                if (travel.TravelPic !=null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await travel.TravelPic.CopyToAsync(memoryStream);
                       travel.TravelPicData = memoryStream.ToArray();
                        travel.ProfilePictureContentType = travel.TravelPic.ContentType;    
                    }
                }
                   await  _service.AddAsync(travel);
                return RedirectToAction("Index1");

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
                if (travel.TravelPic != null && travel.TravelPic.Length >0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await travel.TravelPic.CopyToAsync(memoryStream);
                        travel.TravelPicData = memoryStream.ToArray();
                        travel.ProfilePictureContentType = travel.TravelPic.ContentType;
                    }
                }
                await _service.UpdateAsync(id, travel);
                await _service.DeleteAsync(id);
                return RedirectToAction("Index1");
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reservation(int travelId, int reservedSeats)
        {
            // Retrieve the current user
            var user = await _userManager.GetUserAsync(User);

            // Retrieve the travel
            var travel = await _db.Travels.FindAsync(travelId);

            // Check if the travel and user exist
            if (travel == null || user == null)
            {
                return NotFound(); // Handle the case where travel or user is not found
            }

            // Check if there are enough available seats
            if (travel.Seats < reservedSeats)
            {
                // Handle case where there aren't enough available seats
                ModelState.AddModelError("reservedSeats", "Not enough available seats.");

                // You can also add a TempData message to display a warning on the redirected page
                TempData["ReservationWarning"] = "Not enough available seats.";


                // Redirect back to the Index1 page or any other page you want
                return RedirectToAction("Index1");
            }

            // Create a new reservation
            var reservation = new Reserve
            {
                UserID = user.Id,
                TravelID = travelId,
                ReservedSeats = reservedSeats,
                ReservationDate = DateTime.Now
            };

            // Update the available seats in the travel
            travel.Seats -= reservedSeats;

            // Add the reservation to the context and save changes
            _db.Reserves.Add(reservation);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index1");
        }


        //public IActionResult FilterTravels(TravelDestinations startDestination, TravelDestinations endDestination)
        //{
        //    var startDestinationString = startDestination.ToString();
        //    var endDestinationString = endDestination.ToString();

        //    var filteredTravels = _db.Travels
        //        .Where(t =>
        //            (startDestination == 0 || t.StartDestination.ToString().Contains(startDestinationString))
        //            && (endDestination == 0 || t.EndDestination.ToString().Contains(endDestinationString)))
        //        .ToList();
        //    ViewBag.AllTravels = allTravels;
        //    ViewBag.FilteredTravels = filteredTravels;

        //    return View(filteredTravels);
        //}




    }
}
