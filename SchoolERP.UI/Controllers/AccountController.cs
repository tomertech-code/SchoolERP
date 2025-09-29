using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolERP.Data.Entities;
using SchoolERP.UI.Helper;
using SchoolERP.UI.Models;

namespace SchoolERP.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        // 🔹 GET: Login
        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        // 🔹 POST: Login
        // 🔹 POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(
                        user.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);

                    if (result.Succeeded)
                    {
                        var roles = await _userManager.GetRolesAsync(user);
                        SessionHelper.SetString(HttpContext.Session, "Role", roles.FirstOrDefault() ?? "User");

                        // ✅ Store session using SessionHelper
                        SessionHelper.SetString(HttpContext.Session, "Roles", user.Id);
                        SessionHelper.SetString(HttpContext.Session, "FullName", user.FullName ?? "");
                        SessionHelper.SetString(HttpContext.Session, "UserName", user.UserName ?? "");
                        SessionHelper.SetString(HttpContext.Session, "Email", user.Email ?? "");

                        SessionHelper.SetString(HttpContext.Session, "Role", roles.FirstOrDefault() ?? "User");

                        // ✅ Redirect based on role
                        if (roles.Contains("Admin"))
                            return RedirectToAction("AdminDashboard", "Home");

                        if (roles.Contains("Teacher"))
                            return RedirectToAction("TeacherDashboard", "Home");

                        if (roles.Contains("Student"))
                            return RedirectToAction("StudentDashboard", "Home");

                        if (roles.Contains("Parent"))
                            return RedirectToAction("ParentDashboard", "Home");

                        // Default redirect if no role matched
                        return RedirectToLocal(returnUrl);
                    }

                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }

                ModelState.AddModelError(string.Empty, "User not found.");
            }

            return View(model);
        }


        // 🔹 GET: Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // 🔹 POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email,FullName =model.FullName };
                var result = await _userManager.CreateAsync(user, model.Password);
           
                if (result.Succeeded)
                {
                    // Ensure role exists
                    if (!await _roleManager.RoleExistsAsync(model.Role))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(model.Role));
                    }

                    // Assign role
                    await _userManager.AddToRoleAsync(user, model.Role);

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
         
            return View(model);
        }

        // 🔹 POST: Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            // Clear session with helper
            SessionHelper.Clear(HttpContext.Session);

            return RedirectToAction("Login", "Account");
        }


        // 🔹 Access Denied
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        private IActionResult RedirectToLocal(string? returnUrl)
        {
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }

}
