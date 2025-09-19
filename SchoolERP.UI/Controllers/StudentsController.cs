using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolERP.BLL.Interfaces;
using SchoolERP.Common.Logging;
using SchoolERP.Data.Entities;

namespace SchoolERP.UI.Controllers
{
   
        public class StudentsController : Controller
        {
            private readonly IStudentService _studentService;
        private readonly ILoggerManager _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IClassService _classService;
        public StudentsController(IStudentService studentService, UserManager<ApplicationUser> userManager, IClassService classService, ILoggerManager logger)
            {
            _studentService = studentService;
            _logger = logger;
            _userManager = userManager;
            _classService = classService;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            _logger.LogInfo("Fetching student list...");
            var result = await _studentService.GetAllStudentsAsync();

            if (result.Success)
            {
                // 👇 send only Data (IEnumerable<Student>) to the View
                return View(result.Data);
            }

            ViewBag.Error = result.Message;
            return View(new List<Student>());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int id)
            {
                var result = await _studentService.GetStudentByIdAsync(id);

                if (!result.Success || result.Data == null)
                {
                    return NotFound();
                }

                return View(result.Data);
            }

        // GET: Students/Create
        public async Task<IActionResult> CreateStudent()
        {
            // Fetch users for the dropdown from Identity
            var users = await _userManager.Users.ToListAsync();  // Get all users from Identity
            ViewBag.UserId = new SelectList(users, "Id", "UserName"); // Simplified dropdown

            // Fetch classes for the dropdown
            var classes = await _classService.GetAllClassesAsync();  // Assuming you have this service to get classes
            ViewBag.ClassId = new SelectList(classes, "ClassId", "ClassName"); // Simplified dropdown

            return View();
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                var result = await _studentService.AddStudentAsync(student);
                if (result.Success)
                {
                    return RedirectToAction(nameof(Index));
                }

                ViewBag.Error = result.Message;
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> EditStudent(int id)
            {
                var result = await _studentService.GetStudentByIdAsync(id);

                if (!result.Success || result.Data == null)
                {
                    return NotFound();
                }

                return View(result.Data);
            }

            // POST: Students/Edit/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> EditStudent(int id, Student student)
            {
                if (id != student.StudentId) return BadRequest();

                if (ModelState.IsValid)
                {
                    var result = await _studentService.UpdateStudentAsync(student);
                    if (result.Success)
                        return RedirectToAction(nameof(Index));

                    ViewBag.Error = result.Message;
                }

                return View(student);
            }

            // GET: Students/Delete/5
            public async Task<IActionResult> DeleteStudent(int id)
            {
                var result = await _studentService.GetStudentByIdAsync(id);

                if (!result.Success || result.Data == null)
                {
                    return NotFound();
                }

                return View(result.Data);
            }

            // POST: Students/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var result = await _studentService.DeleteStudentAsync(id);
                if (result.Success)
                    return RedirectToAction(nameof(Index));

                ViewBag.Error = result.Message;
                return RedirectToAction(nameof(Index));
            }
        }
    
}
