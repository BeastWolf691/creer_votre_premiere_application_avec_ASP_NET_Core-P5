using System.Linq;
using Microsoft.AspNetCore.Mvc;
using P5CreateFirstAppDotNet.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using P5CreateFirstAppDotNet.Models.Entities;

namespace P5CreateFirstAppDotNet.Controllers
{
    public class ModelController : Controller
    {
        private readonly IModelRepository _modelRepository;

        public ModelController(IModelRepository modelRepository)
        {
            _modelRepository = modelRepository;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Admin()
        {
            var models = await _modelRepository.GetAllModelsAsync();
            return View(models.OrderByDescending(m => m.ModelId));
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
        public async Task<IActionResult> Create(Model model)
        {
            if (ModelState.IsValid)
            {
                await _modelRepository.AddModelAsync(model);
                return RedirectToAction("Models");
            }
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(Model model)
        {
            if (ModelState.IsValid)
            {
                await _modelRepository.UpdateModelAsync(model);
                return RedirectToAction("Models");
            }
            return View(model);

        }
    }
}
