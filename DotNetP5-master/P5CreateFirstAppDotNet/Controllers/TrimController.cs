using System.Linq;
using Microsoft.AspNetCore.Mvc;
using P5CreateFirstAppDotNet.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using P5CreateFirstAppDotNet.Models.Entities;

namespace P5CreateFirstAppDotNet.Controllers
{
    public class TrimController : Controller
    {
        private readonly ITrimRepository _trimRepository;

        public TrimController(ITrimRepository trimRepository)
        {
            _trimRepository = trimRepository;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Admin()
        {
            var trims = await _trimRepository.GetAllTrimsAsync();
            return View(trims.OrderByDescending(t => t.TrimId));
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
        public async Task<IActionResult> Create(Trim trim)
        {
            if (ModelState.IsValid)
            {
                await _trimRepository.AddTrimAsync(trim);
                return RedirectToAction("Trims");
            }
            return View(trim);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(Trim trim)
        {
            if (ModelState.IsValid)
            {
                await _trimRepository.UpdateTrimAsync(trim);
                return RedirectToAction("Trims");
            }
            return View(trim);

        }
    }
}
