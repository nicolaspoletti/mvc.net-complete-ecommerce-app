using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class PlatformsController : Controller
    {
        private readonly IPlatformsService _service;

        public PlatformsController(IPlatformsService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allPlatforms = await _service.GetAllAsync();
            return View(allPlatforms);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("PlatformLogoURL,PlatformName,PlatformDescription")] Platform platform)
        {
            if(!ModelState.IsValid) return View(platform);

            await _service.AddAsync(platform);

            return RedirectToAction(nameof(Index));

        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var platformDetails = await _service.GetByIdAsync(id);

            if(platformDetails == null) return View("NotFound");

            return View(platformDetails);
        }

        

        public async Task<IActionResult> Edit(int id)
        {
            var platformDetails = await _service.GetByIdAsync(id);

            if (platformDetails == null) return View("NotFound");

            return View(platformDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PlatformLogoURL,PlatformName,PlatformDescription")] Platform platform)
        {
            if (!ModelState.IsValid) return View(platform);

            await _service.UpdateAsync(id, platform);

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(int id)
        {
            var platformDetails = await _service.GetByIdAsync(id);

            if (platformDetails == null) return View("NotFound");

            return View(platformDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var platformDetails = await _service.GetByIdAsync(id);

            if (platformDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));

        }
    }
}
