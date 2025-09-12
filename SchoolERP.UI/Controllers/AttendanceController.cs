using Microsoft.AspNetCore.Mvc;
using SchoolERP.BLL.Interfaces;
using SchoolERP.Data.Entities;

namespace SchoolERP.UI.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        // GET: Attendance
        public async Task<IActionResult> AttendeceList()
        {
            var result = await _attendanceService.GetAllAsync();
            return View(result.Data);
        }

        // GET: Attendance/Create
        public IActionResult InsertAttendece()
        {
            return View();
        }

        // POST: Attendance/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InsertAttendece(Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                await _attendanceService.AddAsync(attendance);
                return RedirectToAction(nameof(Index));
            }
            return View(attendance);
        }

        // GET: Attendance/Edit/5
        public async Task<IActionResult> AttendanceEdit(int id)
        {
            var result = await _attendanceService.GetByIdAsync(id);
            if (!result.Success) return NotFound();

            return View(result.Data);
        }

        // POST: Attendance/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AttendanceEdit(int id, Attendance attendance)
        {
            if (id != attendance.AttendanceId) return BadRequest();

            if (ModelState.IsValid)
            {
                await _attendanceService.UpdateAsync(attendance);
                return RedirectToAction(nameof(Index));
            }
            return View(attendance);
        }

        // GET: Attendance/Delete/5
        public async Task<IActionResult> AttendanceDelete(int id)
        {
            var result = await _attendanceService.GetByIdAsync(id);
            if (!result.Success) return NotFound();

            return View(result.Data);
        }

        // POST: Attendance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _attendanceService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
