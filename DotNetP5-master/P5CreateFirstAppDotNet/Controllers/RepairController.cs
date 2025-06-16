using System.Linq;
using Microsoft.AspNetCore.Mvc;
using P5CreateFirstAppDotNet.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using P5CreateFirstAppDotNet.Models.Entities;

namespace P5CreateFirstAppDotNet.Controllers
{
    public class RepairController : Controller
    {
        private readonly IRepairRepository _repairRepository;
        public RepairController(IRepairRepository repairRepository)
        {
            _repairRepository = repairRepository;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var repairs = await _repairRepository.GetAllRepairsAsync();
            return View(repairs.OrderByDescending(r => r.RepairId));
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var repair = _repairRepository.GetRepairByIdAsync(id).Result;
            if (repair == null)
            {
                return NotFound();
            }
            return View(repair);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var repair = _repairRepository.GetRepairByIdAsync(id.Value).Result;
            if (repair == null)
            {
                return NotFound();
            }
            return View(repair);
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Repair repair)
        {
            if (ModelState.IsValid)
            {
                await _repairRepository.AddRepairAsync(repair);
                return RedirectToAction("Index");
            }
            return View(repair);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Repair repair)
        {
            if (ModelState.IsValid)
            {
                await _repairRepository.UpdateRepairAsync(repair);
                return RedirectToAction("Index");
            }
            return View(repair);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmation(int id)
        {
            var repair = await _repairRepository.GetRepairByIdAsync(id);
            if (repair == null)
            {
                return NotFound();
            }
            await _repairRepository.DeleteRepairAsync(id);
            return View("DeleteConfirmation", repair);
        }
    }
}
