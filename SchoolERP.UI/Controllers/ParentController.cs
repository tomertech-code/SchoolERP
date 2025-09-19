using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolERP.BLL.Interfaces;
using SchoolERP.Data.Entities;

namespace SchoolERP.UI.Controllers
{
    [Authorize(Roles = "Admin,Teacher")]
    public class ParentController : Controller
    {
        private readonly IParentService _parentService;
        private readonly IStudentService _studentService;

        public ParentController(IParentService parentService, IStudentService studentService)
        {
            _parentService = parentService;
            _studentService = studentService;
        }

        public async Task<IActionResult> Index()
        {
            var parents = await _parentService.GetAllAsync();
            return View(parents);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Parent parent)
        {
            if (ModelState.IsValid)
            {
                await _parentService.CreateAsync(parent);
                return RedirectToAction(nameof(Index));
            }
            return View(parent);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var parent = await _parentService.GetByIdAsync(id);
            if (parent == null) return NotFound();
            return View(parent);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Parent parent)
        {
            if (ModelState.IsValid)
            {
                await _parentService.UpdateAsync(parent);
                return RedirectToAction(nameof(Index));
            }
            return View(parent);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _parentService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // Assign Student
        public async Task<IActionResult> AssignStudent(int parentId)
        {
            ViewBag.Students = new SelectList(await _studentService.GetAllAsync(), "Id", "FullName");
            ViewBag.ParentId = parentId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AssignStudent(int parentId, int studentId)
        {
            await _parentService.AssignStudentAsync(parentId, studentId);
            return RedirectToAction(nameof(Details), new { id = parentId });
        }

        public async Task<IActionResult> Details(int id)
        {
            var parent = await _parentService.GetByIdAsync(id);
            if (parent == null) return NotFound();

            var children = await _parentService.GetChildrenAsync(id);
            ViewBag.Children = children;
            return View(parent);
        }
    }
}
