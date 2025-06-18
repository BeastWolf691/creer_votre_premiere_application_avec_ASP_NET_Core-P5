using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using P5CreateFirstAppDotNet.Data;
using P5CreateFirstAppDotNet.Models.Entities;
using P5CreateFirstAppDotNet.Models.Repositories;
using P5CreateFirstAppDotNet.Models.ViewModels;

namespace P5CreateFirstAppDotNet.Controllers
{
    public class StatusController : Controller
    {
        private readonly IStatusRepository _statusRepository;

        public StatusController(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }

        // GET: Status
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var statuses = await _statusRepository.GetAllStatusesAsync();
            return View(statuses.OrderByDescending(s => s.StatusId));
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View(new StatusViewModel());
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var status = _statusRepository.GetStatusByIdAsync(id).Result;
            if (status == null)
            {
                return NotFound();
            }

            var model = new StatusViewModel
            {
                StatusId = status.StatusId,
                Name = status.Name
            };
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var status = _statusRepository.GetStatusByIdAsync(id.Value).Result;
            if (status == null)
            {
                return NotFound();
            }
            var model = new StatusViewModel
            {
                StatusId = status.StatusId,
                Name = status.Name
            };
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StatusViewModel model)
        {
            if (ModelState.IsValid)
            {
                var status = new Status
                {
                    Name = model.Name
                };
                await _statusRepository.AddStatusAsync(status);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(StatusViewModel model)
        {
            if (ModelState.IsValid)
            {
                var status = await _statusRepository.GetStatusByIdAsync(model.StatusId);
                if (status == null)
                {
                    return NotFound();
                }
                status.Name = model.Name;

                await _statusRepository.UpdateStatusAsync(status);
                return RedirectToAction("Index");
            }
            return View(model);
        }


        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmation(int id)
        {
            var status = await _statusRepository.GetStatusByIdAsync(id);
            if (status == null)
            {
                return NotFound();
            }
            await _statusRepository.DeleteStatusAsync(id);

            var model = new StatusViewModel
            {
                StatusId = status.StatusId,
                Name = status.Name
            };
            return View("DeleteConfirmation", model);
        }
    }
}
