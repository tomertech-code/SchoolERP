using Microsoft.AspNetCore.Mvc;
using SchoolERP.BLL.Interfaces;
using SchoolERP.Data.Entities;

namespace SchoolERP.UI.Controllers
{
    public class AssignmentsController : Controller
    {
        private readonly IAssignmentService _assignmentService;

        public AssignmentsController(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }

        public async Task<IActionResult> AssignmentList()
        {
            var assignments = await _assignmentService.GetAllAsync();
            return View(assignments);
        }

        public IActionResult CreateAssignment()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAssignment(Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                await _assignmentService.AddAsync(assignment);
                return RedirectToAction(nameof(Index));
            }
            return View(assignment);
        }

        public async Task<IActionResult> EditAssignment(int id)
        {
            var assignment = await _assignmentService.GetByIdAsync(id);
            if (assignment == null) return NotFound();
            return View(assignment);
        }

        [HttpPost]
        public async Task<IActionResult> EditAssignment(Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                await _assignmentService.UpdateAsync(assignment);
                return RedirectToAction(nameof(Index));
            }
            return View(assignment);
        }

        public async Task<IActionResult> DeleteAssignment(int id)
        {
            var assignment = await _assignmentService.GetByIdAsync(id);
            if (assignment == null) return NotFound();
            return View(assignment);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _assignmentService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
