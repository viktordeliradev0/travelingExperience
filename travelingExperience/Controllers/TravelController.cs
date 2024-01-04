using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using travelingExperience.Data;
using travelingExperience.Data.Services;
using travelingExperience.Models;
using travelingExperience.Entity;

namespace sharedTravel.Controllers
{
    public class TravelController : Controller
    {

        private readonly ITravelsService _service;

        public TravelController(ITravelsService service)
        {
            _service = service;
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
        public async Task<IActionResult> Info(int id)
        {
            var TravelDetails = await _service.GetByIdAsync(id);
            if (TravelDetails == null) return View("Not Found");
            return View(TravelDetails);

        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create([Bind("TravelID,StartDestination,EndDestination,Descrition,StartDate,EndDate,Price,Seats")] Travel travel)
        {
            if (!ModelState.IsValid)
            {
                return View(travel);
            }
            await _service.AddAsync(travel);
            return RedirectToAction("Index");
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
                return View(travel);
            }
            await _service.UpdateAsync(id, travel);
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
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
