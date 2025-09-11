using Microsoft.AspNetCore.Mvc;
using SchoolERP.BLL.Interfaces;
using SchoolERP.Data.Entities;

namespace SchoolERP.UI.Controllers
{
    public class ClassesController : Controller
    {
        private readonly IClassService _classService;

        public ClassesController(IClassService classService)
        {
            _classService = classService;
        }

        public async Task<IActionResult> ClassList()
        {
            var classes = await _classService.GetAllClassesAsync();
            return View(classes);
        }

        [HttpGet]
        public IActionResult CreateClass() => View();

        [HttpPost]
        public async Task<IActionResult> CreateClass(Class cls)
        {
            if (ModelState.IsValid)
            {
                await _classService.AddClassAsync(cls);
                return RedirectToAction(nameof(Index));
            }
            return View(cls);
        }

        [HttpGet]
        public async Task<IActionResult> EditClass(int id)
        {
            var cls = await _classService.GetClassByIdAsync(id);
            if (cls == null) return NotFound();
            return View(cls);
        }

        [HttpPost]
        public async Task<IActionResult> EditClass(Class cls)
        {
            if (ModelState.IsValid)
            {
                await _classService.UpdateClassAsync(cls);
                return RedirectToAction(nameof(Index));
            }
            return View(cls);
        }

        public async Task<IActionResult> DeleteClass(int id)
        {
            await _classService.DeleteClassAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
