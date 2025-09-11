using Microsoft.AspNetCore.Mvc;
using SchoolERP.BLL.Interfaces;
using SchoolERP.Data.Entities;

namespace SchoolERP.UI.Controllers
{
   

        public class StudentComplaintController : Controller
        {
            private readonly IStudentComplaintService _studentComplaintService;

            public StudentComplaintController(IStudentComplaintService studentComplaintService)
            {
                _studentComplaintService = studentComplaintService;
            }

            // GET: Complaints List
            public async Task<IActionResult> StudentComplaintList()
            {
                var response = await _studentComplaintService.GetAllComplaintsAsync();
                if (!response.Success)
                    return View("Error", response.Message);

                return View(response.Data);
            }

            // GET: Complaint Details
            public async Task<IActionResult> ComplaintDetails(int id)
            {
                var response = await _studentComplaintService.GetComplaintByIdAsync(id);
                if (!response.Success)
                    return NotFound(response.Message);

                return View(response.Data);
            }

            // GET: Create Complaint
            public IActionResult CreateComplaint()
            {
                return View();
            }

            // POST: Create Complaint
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> CreateComplaint(StudentComplaint complaint)
            {
                if (ModelState.IsValid)
                {
                    var response = await _studentComplaintService.AddComplaintAsync(complaint);
                    if (response.Success)
                        return RedirectToAction(nameof(Index));

                    ModelState.AddModelError("", response.Message);
                }
                return View(complaint);
            }

            // GET: Edit Complaint
            public async Task<IActionResult> EditComplaint(int id)
            {
                var response = await _studentComplaintService.GetComplaintByIdAsync(id);
                if (!response.Success)
                    return NotFound(response.Message);

                return View(response.Data);
            }

            // POST: Edit Complaint
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> EditComplaint(StudentComplaint complaint)
            {
                if (ModelState.IsValid)
                {
                    var response = await _studentComplaintService.UpdateComplaintAsync(complaint);
                    if (response.Success)
                        return RedirectToAction(nameof(Index));

                    ModelState.AddModelError("", response.Message);
                }
                return View(complaint);
            }

            // GET: Delete Complaint
            public async Task<IActionResult> DeleteComplaint(int id)
            {
                var response = await _studentComplaintService.GetComplaintByIdAsync(id);
                if (!response.Success)
                    return NotFound(response.Message);

                return View(response.Data);
            }

            // POST: Delete Complaint
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var response = await _studentComplaintService.DeleteComplaintAsync(id);
                if (response.Success)
                    return RedirectToAction(nameof(Index));

                return View("Error", response.Message);
            }
        }
    }
