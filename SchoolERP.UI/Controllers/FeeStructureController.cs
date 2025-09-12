using Microsoft.AspNetCore.Mvc;
using SchoolERP.BLL.Interfaces;
using SchoolERP.Data.Entities;

namespace SchoolERP.UI.Controllers
{
    public class FeeStructureController : Controller
    {
        private readonly IFeeStructureService _service;

        public FeeStructureController(IFeeStructureService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _service.GetAllAsync();
            return View(result.Data);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FeeStructure structure)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(structure);
                return RedirectToAction(nameof(Index));
            }
            return View(structure);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (!result.Success) return NotFound();
            return View(result.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(FeeStructure structure)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(structure);
                return RedirectToAction(nameof(Index));
            }
            return View(structure);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (!result.Success) return NotFound();
            return View(result.Data);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
