

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolERP.BLL.Interfaces;
using SchoolERP.Data.Entities;
using SchoolERP.Data;
using SchoolERP.Data.DbContext;

namespace SchoolERP.UI.Controllers
{
    public class TimetableController : Controller
    {
        private readonly ITimetableService _timetableService;
        private readonly SchoolERPDbContext _context;

        public TimetableController(ITimetableService timetableService, SchoolERPDbContext context)
        {
            _timetableService = timetableService;
            _context = context;
        }

        // Show all timetables
        public async Task<IActionResult> Index()
        {
            var timetables = await _timetableService.GetAllTimetablesAsync();
            return View(timetables);
        }
        public async Task<IActionResult> studentTimeTable()
        {
            return View();
        }


        // Show form for adding a new timetable
        public IActionResult AddTimetable()
        {
            LoadDropdowns();
            return View();
        }

        // Save new timetable
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTimetable(Timetable timetable)
        {
            if (ModelState.IsValid)
            {
                await _timetableService.AddTimetableAsync(timetable);
                return RedirectToAction(nameof(Index));
            }

            LoadDropdowns(timetable);
            return View(timetable);
        }

        // Show form for editing timetable
        public async Task<IActionResult> EditTimetable(int id)
        {
            var timetable = await _timetableService.GetTimetableByIdAsync(id);
            if (timetable == null)
                return NotFound();

            LoadDropdowns(timetable);
            return View(timetable);
        }

        // Save edited timetable
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTimetable(int id, Timetable timetable)
        {
            if (id != timetable.TimetableId)
                return BadRequest();

            if (ModelState.IsValid)
            {
                await _timetableService.UpdateTimetableAsync(timetable);
                return RedirectToAction(nameof(Index));
            }

            LoadDropdowns(timetable);
            return View(timetable);
        }

        // Show confirmation before deleting timetable
        public async Task<IActionResult> DeleteTimetable(int id)
        {
            var timetable = await _timetableService.GetTimetableByIdAsync(id);
            if (timetable == null)
                return NotFound();

            return View(timetable);
        }

        // Delete timetable (confirmed)
        [HttpPost, ActionName("DeleteTimetable")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteTimetableConfirmed(int id)
        {
            await _timetableService.DeleteTimetableAsync(id);
            return RedirectToAction(nameof(Index));
        }

        #region Helpers
        private void LoadDropdowns(Timetable? timetable = null)
        {
            ViewBag.Classes = new SelectList(_context.Classes, "ClassId", "ClassName", timetable?.ClassId);
            ViewBag.Sections = new SelectList(_context.Sections, "SectionId", "SectionName", timetable?.SectionId);
            ViewBag.Subjects = new SelectList(_context.Subjects, "SubjectId", "SubjectName", timetable?.SubjectId);
            ViewBag.Teachers = new SelectList(_context.Teachers, "TeacherId", "Name", timetable?.TeacherId);
        }
        public IActionResult ClassWiseTimetable()
        {
            ViewBag.Classes = new SelectList(_context.Classes, "ClassId", "ClassName");
            return View();
        }

        // POST: Timetable/ClassWise
        [HttpPost]
        public async Task<IActionResult> ClassWiseTimetable(int classId)
        {
            ViewBag.Classes = new SelectList(_context.Classes, "ClassId", "ClassName", classId);

            var timetables = await _timetableService.GetTimetableByClassAsync(classId);
            return View(timetables);
        }
        #endregion
    }
}
