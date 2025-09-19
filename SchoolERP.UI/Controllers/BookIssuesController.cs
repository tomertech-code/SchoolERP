using Microsoft.AspNetCore.Mvc;
using SchoolERP.BLL.Interfaces;
using SchoolERP.Data.Entities;

namespace SchoolERP.UI.Controllers
{
    public class BookIssuesController : Controller
    {
        private readonly IBookIssueService _bookIssueService;

        public BookIssuesController(IBookIssueService bookIssueService)
        {
            _bookIssueService = bookIssueService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _bookIssueService.GetAllIssuesAsync();
            return View(result.Data);
        }

        public IActionResult IssueBook() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IssueBook(BookIssue issue)
        {
            if (ModelState.IsValid)
            {
                await _bookIssueService.IssueBookAsync(issue);
                return RedirectToAction(nameof(Index));
            }
            return View(issue);
        }

        public async Task<IActionResult> ReturnBook(int id)
        {
            await _bookIssueService.ReturnBookAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _bookIssueService.GetIssueByIdAsync(id);
            if (!result.Success) return NotFound();
            return View(result.Data);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _bookIssueService.DeleteIssueAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
