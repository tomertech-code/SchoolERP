using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolERP.Data.Entities;

namespace SchoolERP.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var roles = await _userManager.GetRolesAsync(user);

            if (roles.Contains("Admin"))
                return RedirectToAction("AdminDashboard");

            if (roles.Contains("Teacher"))
                return RedirectToAction("TeacherDashboard");

            if (roles.Contains("Student"))
                return RedirectToAction("StudentDashboard");

            if (roles.Contains("Parent"))
                return RedirectToAction("ParentDashboard");

            return View();
        }

        public IActionResult AdminDashboard() => View();
        public IActionResult TeacherDashboard() => View();
        public IActionResult StudentDashboard() => View();
        public IActionResult ParentDashboard() => View();
    }
}