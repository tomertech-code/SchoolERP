using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolERP.BLL.Interfaces;
using SchoolERP.Data.Entities;

namespace SchoolERP.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StaffController : Controller
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        // List Staff
        public async Task<IActionResult> Index()
        {
            var staff = await _staffService.GetAllAsync();
            return View(staff);
        }

        // Create Staff
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Staff staff)
        {
            if (ModelState.IsValid)
            {
                await _staffService.CreateAsync(staff);
                return RedirectToAction(nameof(Index));
            }
            return View(staff);
        }

        // Edit Staff
        public async Task<IActionResult> Edit(int id)
        {
            var staff = await _staffService.GetByIdAsync(id);
            if (staff == null) return NotFound();
            return View(staff);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Staff staff)
        {
            if (ModelState.IsValid)
            {
                await _staffService.UpdateAsync(staff);
                return RedirectToAction(nameof(Index));
            }
            return View(staff);
        }

        // Delete Staff
        public async Task<IActionResult> Delete(int id)
        {
            await _staffService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // Payroll Management
        public async Task<IActionResult> Payroll(int staffId)
        {
            var payroll = await _staffService.GetPayrollAsync(staffId);
            ViewBag.StaffId = staffId;
            return View(payroll ?? new Payroll { StaffId = staffId });
        }

        [HttpPost]
        public async Task<IActionResult> Payroll(Payroll payroll)
        {
            if (ModelState.IsValid)
            {
                await _staffService.AddOrUpdatePayrollAsync(payroll);
                return RedirectToAction(nameof(Index));
            }
            return View(payroll);
        }
    }

}
