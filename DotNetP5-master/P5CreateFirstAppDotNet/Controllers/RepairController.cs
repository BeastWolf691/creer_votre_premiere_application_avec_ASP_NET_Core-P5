using System.Linq;
using Microsoft.AspNetCore.Mvc;
using P5CreateFirstAppDotNet.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using P5CreateFirstAppDotNet.Models.Entities;
using P5CreateFirstAppDotNet.Models.ViewModels;
using System.Globalization;

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
            return View(new RepairViewModel());
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var repair = await _repairRepository.GetRepairByIdAsync(id);
            if (repair == null)
            {
                return NotFound();
            }

            var model = new RepairViewModel
            {
                RepairId = repair.RepairId,
                Name = repair.Name,
                RepairCost = repair.RepairCost.ToString("F2")
            };

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Console.WriteLine("RepairId reçu dans POST : ");
            var repair = _repairRepository.GetRepairByIdAsync(id);
            if (repair == null)
            {
                return NotFound();
            }

            var viewModel = new RepairViewModel
            {
                RepairId = repair.Result.RepairId,
                Name = repair.Result.Name,
                RepairCost = repair.Result.RepairCost.ToString("F2")
            };
            return View(viewModel);
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RepairViewModel model)
        {
            if (!double.TryParse(model.RepairCost, NumberStyles.Number, new CultureInfo("fr-FR"), out double parsedCost) || parsedCost <= 0)
                {
                    ModelState.AddModelError(nameof(model.RepairCost), "Le coût doit être un nombre valide supérieur à zéro.");
                    return View(model);
                }

                var repair = new Repair
                {
                    Name = model.Name,
                    RepairCost = parsedCost
                };
                await _repairRepository.AddRepairAsync(repair);
                return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RepairViewModel model)
        {

            if (!double.TryParse(model.RepairCost, NumberStyles.Number, new CultureInfo("fr-FR"), out double parsedCost) || parsedCost <= 0)
            {
                ModelState.AddModelError(nameof(model.RepairCost), "Le coût doit être un nombre valide supérieur à zéro.");
                return View(model);
            }

            var repair = await _repairRepository.GetRepairByIdAsync(model.RepairId);
            if (repair == null)
            {
                return NotFound();
            }

            repair.Name = model.Name;
            repair.RepairCost = parsedCost;

            await _repairRepository.UpdateRepairAsync(repair);
            return RedirectToAction("Index");
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
            return View("DeleteConfirmation", new RepairViewModel { Name = repair.Name});
        }
    }
}
