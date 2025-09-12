using Microsoft.AspNetCore.Mvc;
using SchoolERP.BLL.Interfaces;
using SchoolERP.Data.Entities;

namespace SchoolERP.UI.Controllers
{
    public class FeePaymentController : Controller
    {
        private readonly IFeePaymentService _service;

        public FeePaymentController(IFeePaymentService service)
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
        public async Task<IActionResult> Create(FeePayment payment)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(payment);
                return RedirectToAction(nameof(Index));
            }
            return View(payment);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (!result.Success) return NotFound();
            return View(result.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(FeePayment payment)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(payment);
                return RedirectToAction(nameof(Index));
            }
            return View(payment);
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
