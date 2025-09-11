using Microsoft.AspNetCore.Mvc;
using SchoolERP.BLL.Interfaces;
using SchoolERP.Common.Logging;
using SchoolERP.Data.Entities;

namespace SchoolERP.UI.Controllers
{
   
        public class StudentsController : Controller
        {
            private readonly IStudentService _studentService;
        private readonly ILoggerManager _logger;
        public StudentsController(IStudentService studentService, ILoggerManager logger)
            {
            _studentService = studentService;
            _logger = logger;
        }

            // GET: Students
            public async Task<IActionResult> Index()
            {
            _logger.LogInfo("Fetching subjects list...");
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
            public IActionResult CreateStudent()
            {
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
                        return RedirectToAction(nameof(Index));

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
