using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SchoolERP.Common.Constants;
using SchoolERP.Common.DTOs;

namespace SchoolERP.BLL.Interfaces
{
    public interface IRoleService
    {
         Task<ApiResponse<IEnumerable<RoleDto>>> GetAllRolesAsync();
        Task<ApiResponse<RoleDto>> GetRoleByIdAsync(string id);
        Task<ApiResponse<bool>> CreateRoleAsync(string roleName);
        Task<ApiResponse<bool>> UpdateRoleAsync(string roleId, string roleName);
        Task<ApiResponse<bool>> DeleteRoleAsync(string roleId);
    }
}
