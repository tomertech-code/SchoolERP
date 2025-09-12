using Microsoft.AspNetCore.Mvc;
using SchoolERP.BLL.Interfaces;

namespace SchoolERP.UI.Controllers
{
    public class RolesController : Controller
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        // GET: Roles
        public async Task<IActionResult> RolesIndex()
        {
            var result = await _roleService.GetAllRolesAsync();
            return View(result.Data);
        }

        // GET: Roles/Create
        public IActionResult CreateRole()
        {
            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            var result = await _roleService.CreateRoleAsync(roleName);
            if (result.Success)
                return RedirectToAction(nameof(RolesIndex));

            ViewBag.Error = result.Message;
            return View();
        }

        // GET: Roles/Edit/5
        public async Task<IActionResult> EditRole(string id)
        {
            var result = await _roleService.GetRoleByIdAsync(id);
            if (!result.Success) return NotFound();

            return View(result.Data);
        }

        // POST: Roles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRole(string id, string name)
        {
            var result = await _roleService.UpdateRoleAsync(id, name);
            if (result.Success)
                return RedirectToAction(nameof(Index));

            ViewBag.Error = result.Message;
            return View();
        }

        // GET: Roles/Delete/5
        public async Task<IActionResult> DeleteRole(string id)
        {
            var result = await _roleService.GetRoleByIdAsync(id);
            if (!result.Success) return NotFound();

            return View(result.Data);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var result = await _roleService.DeleteRoleAsync(id);
            if (result.Success)
                return RedirectToAction(nameof(RolesIndex));

            ViewBag.Error = result.Message;
            return RedirectToAction(nameof(RolesIndex));
        }
    }
}
