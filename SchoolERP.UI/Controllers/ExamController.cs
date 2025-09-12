using Microsoft.AspNetCore.Mvc;
using SchoolERP.BLL.Interfaces;
using SchoolERP.Data.Entities;

namespace SchoolERP.UI.Controllers
{
    public class ExamController : Controller
    {
        private readonly IExamService _examService;

        public ExamController(IExamService examService)
        {
            _examService = examService;
        }

        // GET: Exam
        public async Task<IActionResult> ExamList()
        {
            var result = await _examService.GetAllAsync();
            return View(result.Data);
        }

        // GET: Exam/Create
        public IActionResult CreateExam()
        {
            return View();
        }

        // POST: Exam/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateExam(Exam exam)
        {
            if (ModelState.IsValid)
            {
                await _examService.AddAsync(exam);
                return RedirectToAction(nameof(Index));
            }
            return View(exam);
        }

        // GET: Exam/Edit/5
        public async Task<IActionResult> EditExam(int id)
        {
            var result = await _examService.GetByIdAsync(id);
            if (!result.Success) return NotFound();

            return View(result.Data);
        }

        // POST: Exam/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditExam(int id, Exam exam)
        {
            if (id != exam.ExamId) return BadRequest();

            if (ModelState.IsValid)
            {
                await _examService.UpdateAsync(exam);
                return RedirectToAction(nameof(Index));
            }
            return View(exam);
        }

        // GET: Exam/Delete/5
        public async Task<IActionResult> DeleteExam(int id)
        {
            var result = await _examService.GetByIdAsync(id);
            if (!result.Success) return NotFound();

            return View(result.Data);
        }

        // POST: Exam/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _examService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
