using System.Linq;
using Microsoft.AspNetCore.Mvc;
using P5CreateFirstAppDotNet.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using P5CreateFirstAppDotNet.Models.Entities;
using P5CreateFirstAppDotNet.Models.Services;
using P5CreateFirstAppDotNet.Models.ViewModels;

namespace P5CreateFirstAppDotNet.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicleService _vehicleService;


        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var vehicleViewModels = await _vehicleService.GetAllVehicleViewModelsAsync();
            if (vehicleViewModels == null || !vehicleViewModels.Any())
            {
                return View("Vehicles");
            }
            return View(vehicleViewModels.OrderByDescending(v => v.VehicleId));
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var vehicle = await _vehicleService.GetVehicleViewModelAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return View(vehicle);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(VehicleViewModel vehicleViewModel)
        {
            if (ModelState.IsValid)
            {
                await _vehicleService.AddVehicleAsync(vehicleViewModel);
                return RedirectToAction("Index");
            }
            return View(vehicleViewModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(VehicleViewModel vehicleViewModel)
        {
            if (ModelState.IsValid)
            {
                await _vehicleService.UpdateVehicleAsync(vehicleViewModel);
                return RedirectToAction("Index");
            }
            return View(vehicleViewModel);
        }
    }
}
