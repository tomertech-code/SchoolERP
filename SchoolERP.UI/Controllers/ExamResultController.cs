using Microsoft.AspNetCore.Mvc;
using SchoolERP.BLL.Interfaces;
using SchoolERP.Data.Entities;

namespace SchoolERP.UI.Controllers
{
    public class ExamResultController : Controller
    {
        private readonly IExamResultService _examResultService;
        private readonly IExamService _examService;
        private readonly IStudentService _studentService;

        public ExamResultController(
            IExamResultService examResultService,
            IExamService examService,
            IStudentService studentService)
        {
            _examResultService = examResultService;
            _examService = examService;
            _studentService = studentService;
        }

        // GET: ExamResult
        public async Task<IActionResult> Index()
        {
            var result = await _examResultService.GetAllAsync();
            return View(result.Data);
        }

        // GET: ExamResult/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Exams = await _examService.GetAllAsync();
            ViewBag.Students = await _studentService.GetAllStudentsAsync();
            return View();
        }

        // POST: ExamResult/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExamResult examResult)
        {
            if (ModelState.IsValid)
            {
                await _examResultService.AddAsync(examResult);
                return RedirectToAction(nameof(Index));
            }
            return View(examResult);
        }

        // GET: ExamResult/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _examResultService.GetByIdAsync(id);
            if (!result.Success) return NotFound();

            ViewBag.Exams = await _examService.GetAllAsync();
            ViewBag.Students = await _studentService.GetAllStudentsAsync();
            return View(result.Data);
        }

        // POST: ExamResult/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ExamResult examResult)
        {
            if (id != examResult.ResultId) return BadRequest();

            if (ModelState.IsValid)
            {
                await _examResultService.UpdateAsync(examResult);
                return RedirectToAction(nameof(Index));
            }
            return View(examResult);
        }

        // GET: ExamResult/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _examResultService.GetByIdAsync(id);
            if (!result.Success) return NotFound();

            return View(result.Data);
        }

        // POST: ExamResult/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _examResultService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
