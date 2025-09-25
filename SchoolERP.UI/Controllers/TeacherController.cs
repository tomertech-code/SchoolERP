using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolERP.BLL.Interfaces;
using SchoolERP.Data.DbContext;
using SchoolERP.Data.Entities;

namespace SchoolERP.UI.Controllers
{

    //[AllowAnonymous]
    [Authorize(Roles = "Admin")]
    public class TeacherController : Controller
        {
            private readonly ITeacherService _teacherService;
        private readonly SchoolERPDbContext _context;
        public TeacherController(ITeacherService teacherService, SchoolERPDbContext context)
            {
                _teacherService = teacherService;
            _context = context;
        }

        // GET: Teacher
        public async Task<IActionResult> Index()
        {
            var result = await _teacherService.GetAllTeachersAsync();
            if (result.Success)
            {
                // 👇 Only send the Data (list of teachers) to the View
                return View(result.Data);
            }
            else
            {
                // Optionally show empty list with error
                ViewBag.Error = result.Message;
                return View(new List<Teacher>());
            }
        }

        // GET: Teacher/Details/5
        public async Task<IActionResult> Details(int id)
            {
                var teacher = await _teacherService.GetTeacherByIdAsync(id);
                if (teacher == null) return NotFound();
                return View(teacher);
            }

        // GET: Teacher/Create
            public IActionResult Create()
        {
            ViewBag.SubjectId = new SelectList(_context.Subjects, "SubjectId", "SubjectName");
            return View();
            }

        // POST: Teacher/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Teacher teacher)
        {
            if (!ModelState.IsValid)
            {
                return View(teacher);
            }

            try
            {
                // ignore Photo completely
                _context.Teachers.Add(teacher);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Teacher added successfully!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                TempData["ErrorMessage"] = "Something went wrong while adding the teacher.";
                return View(teacher);
            }
        }


        // GET: Teacher/Edit/5
        public async Task<IActionResult> Edit(int id)
            {
                var teacher = await _teacherService.GetTeacherByIdAsync(id);
                if (teacher == null) return NotFound();
                return View(teacher);
            }

            // POST: Teacher/Edit/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, Teacher teacher)
            {
                if (id != teacher.TeacherId) return BadRequest();

                if (ModelState.IsValid)
                {
                    await _teacherService.UpdateTeacherAsync(teacher);
                    return RedirectToAction(nameof(Index));
                }
                return View(teacher);
            }

            // GET: Teacher/Delete/5
            public async Task<IActionResult> Delete(int id)
            {
                var teacher = await _teacherService.GetTeacherByIdAsync(id);
                if (teacher == null) return NotFound();
                return View(teacher);
            }

            // POST: Teacher/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                await _teacherService.DeleteTeacherAsync(id);
                return RedirectToAction(nameof(Index));
            }
        }
    
}
