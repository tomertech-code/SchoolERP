using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
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
        //[AllowAnonymous]
        //public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        //{
        //    try
        //    {
        //        returnUrl ??= Url.Content("~/");
        //        //await _signInManager.SignOutAsync();
        //        //await HttpContext.SignOutAsync();
        //        var ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        //        var currentDatetime = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
        //        var watermarkText = $" {ipAddress}\n  {currentDatetime}";


        //        Login Logins = SessionHelper.GetObjectFromJson<Login>(HttpContext.Session, "User");
        //        ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

        //        if (ModelState.IsValid)
        //        {
        //            if (Logins.IsNotNull())
        //            {
        //                // ModelState.AddModelError("", "Other User Already Logged In Or Not Properly Logged Out");
        //            }
        //            else
        //            {
        //                ViewData["UserName"] = Input.UserName;

        //                var result = await _signInManager.PasswordSignInAsync(Input.UserName, Input.Password, Input.RememberMe, lockoutOnFailure: true);

        //                if (result.Succeeded)  /// registered user
        //                {
        //                    ApplicationUser userdet = await _userManager.FindByNameAsync(Input.UserName);

        //                    if (userdet != null)
        //                    {
        //                        var unitdetl = await _unitRepository.GetUnitDtl(userdet.unitid);
        //                        int cla = await _unitRepository.GetIdCalendar();
        //                        if (unitdetl != null)
        //                        {
        //                            Login Db = new Login();
        //                            userdet.domain_iam = userdet.UserName;
        //                            CommonHelper commonHelper = new CommonHelper(_context);
        //                            var userRank = commonHelper.UserRankDetail(userdet);

        //                            if (userdet.domain_iam != null)   // domain_iam available after registration
        //                            {
        //                                Db.UserName = userdet.UserName;
        //                                Db.Comdid = unitdetl.unitid;
        //                                Db.Corpsid = unitdetl.CorpsId;
        //                                Db.Iamuserid = userdet.domain_iam;
        //                                Db.Unit = unitdetl.UnitName;
        //                                Db.unitid = userdet.unitid;
        //                                Db.UserIntId = userdet.unitid;
        //                                //Db.Rank=userdet.Rank;
        //                                Db.Rank = userRank;
        //                                Db.IcNo = userdet.Icno;
        //                                Db.Offr_Name = userdet.Offr_Name;
        //                                var users = await _userManager.FindByNameAsync(userdet.UserName);
        //                                var usroles = await _userManager.GetRolesAsync(users);
        //                                Db.Role = usroles.Any() ? usroles[0] : "Unit";
        //                                Db.IpAddress = watermarkText;
        //                                Db.cla = cla;
        //                                if (Db.ActualUserName == null)
        //                                {
        //                                    Db.ActualUserName = Input.UserName;
        //                                }
        //                            }
        //                            ///////////////login log//////////////////////
        //                            tbl_LoginLog logs = new tbl_LoginLog();
        //                            var Role = await _userManager.GetRolesAsync(userdet);
        //                            logs.UserId = userdet.UserIntId;
        //                            logs.IP = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        //                            logs.IsActive = true;
        //                            logs.Updatedby = userdet.unitid;
        //                            logs.UpdatedOn = DateTime.Now;
        //                            logs.logindate = DateTime.Now;
        //                            logs.userName = userdet.UserName;
        //                            logs.unitid = userdet.unitid;
        //                            await _userRepository.Add(logs);
        //                            ////////////////End Log////////////////////////
        //                            SessionHelper.SetObjectAsJson(HttpContext.Session, "User", Db);


        //                            if (Db.Role == "Dte")
        //                            {
        //                                HttpContext.Session.SetString("UserName", Input.UserName);
        //                                return RedirectToAction("NewProject", "Home");
        //                            }
        //                            else
        //                            {
        //                                return RedirectToAction("NewProject", "Home");
        //                            }
        //                        }
        //                    }
        //                }
        //                else // application identity failed but IAM login found correct ..  Allow as a StakeHolder
        //                {
        //                    if (Input.UserName != null)
        //                    {
        //                        TempData["UserName"] = Input.UserName;
        //                        HttpContext.Session.SetString("UserName", Input.UserName);

        //                        return RedirectToAction("NewProject", "Home");
        //                    }
        //                }

        //                if (result.IsLockedOut)
        //                {
        //                    ModelState.AddModelError("", "The account is locked out");
        //                    return Page();
        //                }

        //                if (result.RequiresTwoFactor)
        //                {
        //                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
        //                }


        //                ModelState.AddModelError(string.Empty, "Invalid login attempt");
        //                return Page();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        swas.BAL.Utility.Error.ExceptionHandle(ex.Message);
        //        //return Redirect("/Home/Error");
        //    }

        //    return Page();
        //}



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
