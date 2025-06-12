using System.Linq;
using Microsoft.AspNetCore.Mvc;
using P5CreateFirstAppDotNet.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using P5CreateFirstAppDotNet.Models.Entities;

namespace P5CreateFirstAppDotNet.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicleRepository _vehicleRepository;
        public VehicleController(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var vehicles = await _vehicleRepository.GetAllVehicleAsync();
            return View(vehicles.OrderByDescending(v => v.VehicleId));
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                vehicle.CalculateSalePrice();
                await _vehicleRepository.AddVehicleAsync(vehicle);
                return RedirectToAction("Index");
            }
            return View(vehicle);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                vehicle.CalculateSalePrice();
                await _vehicleRepository.UpdateVehicleAsync(vehicle);
                return RedirectToAction("Index");
            }
            return View(vehicle);
        }
    }
}
