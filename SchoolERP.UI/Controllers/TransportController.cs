using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolERP.BLL.Interfaces;
using SchoolERP.Data.Entities;

namespace SchoolERP.UI.Controllers
{
    [Authorize(Roles = "Admin,Staff")]
    public class TransportController : Controller
    {
        private readonly ITransportService _transportService;

        public TransportController(ITransportService transportService)
        {
            _transportService = transportService;
        }

        // ---------------- BUS MANAGEMENT ----------------
        public async Task<IActionResult> Buses()
        {
            var buses = await _transportService.GetAllBusesAsync();
            return View(buses);
        }

        public IActionResult CreateBus()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBus(Bus bus)
        {
            if (ModelState.IsValid)
            {
                await _transportService.CreateBusAsync(bus);
                return RedirectToAction(nameof(Buses));
            }
            return View(bus);
        }

        public async Task<IActionResult> EditBus(int id)
        {
            var bus = await _transportService.GetBusByIdAsync(id);
            if (bus == null) return NotFound();
            return View(bus);
        }

        [HttpPost]
        public async Task<IActionResult> EditBus(Bus bus)
        {
            if (ModelState.IsValid)
            {
                await _transportService.UpdateBusAsync(bus);
                return RedirectToAction(nameof(Buses));
            }
            return View(bus);
        }

        public async Task<IActionResult> DeleteBus(int id)
        {
            await _transportService.DeleteBusAsync(id);
            return RedirectToAction(nameof(Buses));
        }

        // ---------------- STUDENT TRANSPORT ----------------
        public async Task<IActionResult> StudentTransports()
        {
            var mappings = await _transportService.GetAllStudentTransportsAsync();
            return View(mappings);
        }

        public IActionResult AssignStudentToBus()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AssignStudentToBus(StudentTransport mapping)
        {
            if (ModelState.IsValid)
            {
                await _transportService.AssignStudentToBusAsync(mapping);
                return RedirectToAction(nameof(StudentTransports));
            }
            return View(mapping);
        }

        public async Task<IActionResult> RemoveStudentFromBus(int id)
        {
            await _transportService.RemoveStudentFromBusAsync(id);
            return RedirectToAction(nameof(StudentTransports));
        }
    }
}