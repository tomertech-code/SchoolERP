using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolERP.BLL.Interfaces;
using SchoolERP.Data.Entities;

namespace SchoolERP.UI.Controllers
{
    public class SubjectsController : Controller
    {
        private readonly ISubjectService _subjectService;
        private readonly IClassService _classService;

        public SubjectsController(ISubjectService subjectService, IClassService classService)
        {
            _subjectService = subjectService;
            _classService = classService;
        }

        public async Task<IActionResult> SubjectList()
        {
            var subjects = await _subjectService.GetAllSubjectsAsync();
            return View(subjects);
        }

        [HttpGet]
        public async Task<IActionResult> AddSubjects()
        {
            ViewBag.Classes = new SelectList(await _classService.GetAllClassesAsync(), "ClassId", "ClassName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSubjects(Subject subject)
        {
            if (ModelState.IsValid)
            {
                await _subjectService.AddSubjectAsync(subject);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Classes = new SelectList(await _classService.GetAllClassesAsync(), "ClassId", "ClassName", subject.ClassId);
            return View(subject);
        }

        [HttpGet]
        public async Task<IActionResult> EditSubjects(int id)
        {
            var subject = await _subjectService.GetSubjectByIdAsync(id);
            if (subject == null) return NotFound();

            ViewBag.Classes = new SelectList(await _classService.GetAllClassesAsync(), "ClassId", "ClassName", subject.ClassId);
            return View(subject);
        }

        [HttpPost]
        public async Task<IActionResult> EditSubjects(Subject subject)
        {
            if (ModelState.IsValid)
            {
                await _subjectService.UpdateSubjectAsync(subject);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Classes = new SelectList(await _classService.GetAllClassesAsync(), "ClassId", "ClassName", subject.ClassId);
            return View(subject);
        }

        public async Task<IActionResult> DeleteSubject(int id)
        {
            await _subjectService.DeleteSubjectAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
