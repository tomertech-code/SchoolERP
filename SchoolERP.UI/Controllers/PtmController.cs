using Microsoft.AspNetCore.Mvc;
using SchoolERP.BLL.Interfaces;
using SchoolERP.Data.Entities;

namespace SchoolERP.UI.Controllers
{
   
        public class PtmController : Controller
        {
            private readonly IPtmService _ptmService;

            public PtmController(IPtmService ptmService)
            {
                _ptmService = ptmService;
            }

            // GET: PTM List
            public async Task<IActionResult> PTMList()
            {
                var result = await _ptmService.GetAllAsync();
                return View(result.Data);
            }

            // GET: Create PTM
            public IActionResult Create()
            {
                return View();
            }

            // POST: Create PTM
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> CreatePTM(Ptm ptm)
            {
                if (ModelState.IsValid)
                {
                    await _ptmService.AddAsync(ptm);
                    return RedirectToAction(nameof(Index));
                }
                return View(ptm);
            }

            // GET: Edit PTM
            public async Task<IActionResult> Edit(int id)
            {
                var result = await _ptmService.GetByIdAsync(id);
                if (!result.Success) return NotFound();

                return View(result.Data);
            }

            // POST: Edit PTM
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, Ptm ptm)
            {
                if (id != ptm.Ptmid) return BadRequest();

                if (ModelState.IsValid)
                {
                    await _ptmService.UpdateAsync(ptm);
                    return RedirectToAction(nameof(Index));
                }
                return View(ptm);
            }

            // GET: Delete PTM
            public async Task<IActionResult> Delete(int id)
            {
                var result = await _ptmService.GetByIdAsync(id);
                if (!result.Success) return NotFound();

                return View(result.Data);
            }

            // POST: Delete PTM
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                await _ptmService.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
        }
    }

