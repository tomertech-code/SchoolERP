using Microsoft.AspNetCore.Identity;
using SchoolERP.BLL.Interfaces;
using SchoolERP.Common.DTOs;
using SchoolERP.Common.Constants;

namespace SchoolERP.Business.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleService(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<ApiResponse<IEnumerable<RoleDto>>> GetAllRolesAsync()
        {
            var roles = _roleManager.Roles
                .Select(r => new RoleDto
                {
                    Id = r.Id,
                    Name = r.Name
                })
                .ToList();

            return ApiResponse<IEnumerable<RoleDto>>.Ok(roles);
        }

        public async Task<ApiResponse<RoleDto>> GetRoleByIdAsync(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
                return ApiResponse<RoleDto>.Fail("Role not found");

            return ApiResponse<RoleDto>.Ok(new RoleDto
            {
                Id = role.Id,
                Name = role.Name
            });
        }

        public async Task<ApiResponse<bool>> CreateRoleAsync(string roleName)
        {
            var result = await _roleManager.CreateAsync(new IdentityRole(roleName));
            return result.Succeeded
                ? ApiResponse<bool>.Ok(true, "Role created successfully")
                : ApiResponse<bool>.Fail(string.Join(", ", result.Errors.Select(e => e.Description)));
        }

        public async Task<ApiResponse<bool>> UpdateRoleAsync(string id, string name)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
                return ApiResponse<bool>.Fail("Role not found");

            role.Name = name;
            var result = await _roleManager.UpdateAsync(role);

            return result.Succeeded
                ? ApiResponse<bool>.Ok(true, "Role updated successfully")
                : ApiResponse<bool>.Fail(string.Join(", ", result.Errors.Select(e => e.Description)));
        }

        public async Task<ApiResponse<bool>> DeleteRoleAsync(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
                return ApiResponse<bool>.Fail("Role not found");

            var result = await _roleManager.DeleteAsync(role);

            return result.Succeeded
                ? ApiResponse<bool>.Ok(true, "Role deleted successfully")
                : ApiResponse<bool>.Fail(string.Join(", ", result.Errors.Select(e => e.Description)));
        }
    }
}
