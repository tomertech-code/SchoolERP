using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SchoolERP.BLL.Interfaces;
using SchoolERP.Common.Constants;

namespace SchoolERP.BLL.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleService(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<ApiResponse<IEnumerable<IdentityRole>>> GetAllRolesAsync()
        {
            var roles = _roleManager.Roles.ToList();
            return ApiResponse<IEnumerable<IdentityRole>>.Ok(roles, "Roles retrieved successfully");
        }

        public async Task<ApiResponse<IdentityRole>> GetRoleByIdAsync(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
                return ApiResponse<IdentityRole>.Fail("Role not found");
            return ApiResponse<IdentityRole>.Ok(role, "Role retrieved successfully");
        }

        public async Task<ApiResponse<string>> CreateRoleAsync(string roleName)
        {
            if (await _roleManager.RoleExistsAsync(roleName))
                return ApiResponse<string>.Fail("Role already exists");

            var result = await _roleManager.CreateAsync(new IdentityRole(roleName));
            if (result.Succeeded)
                return ApiResponse<string>.Ok("Role created successfully");

            return ApiResponse<string>.Fail(string.Join(", ", result.Errors.Select(e => e.Description)));
        }

        public async Task<ApiResponse<string>> UpdateRoleAsync(string roleId, string newName)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null) return ApiResponse<string>.Fail("Role not found");

            role.Name = newName;
            var result = await _roleManager.UpdateAsync(role);

            if (result.Succeeded)
                return ApiResponse<string>.Ok("Role updated successfully");

            return ApiResponse<string>.Fail(string.Join(", ", result.Errors.Select(e => e.Description)));
        }

        public async Task<ApiResponse<string>> DeleteRoleAsync(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null) return ApiResponse<string>.Fail("Role not found");

            var result = await _roleManager.DeleteAsync(role);

            if (result.Succeeded)
                return ApiResponse<string>.Ok("Role deleted successfully");

            return ApiResponse<string>.Fail(string.Join(", ", result.Errors.Select(e => e.Description)));
        }
    }
}
