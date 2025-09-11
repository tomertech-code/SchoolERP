using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SchoolERP.Common.Constants;

namespace SchoolERP.BLL.Interfaces
{
    public interface IRoleService
    {
        Task<ApiResponse<IEnumerable<IdentityRole>>> GetAllRolesAsync();
        Task<ApiResponse<IdentityRole>> GetRoleByIdAsync(string roleId);
        Task<ApiResponse<string>> CreateRoleAsync(string roleName);
        Task<ApiResponse<string>> UpdateRoleAsync(string roleId, string newName);
        Task<ApiResponse<string>> DeleteRoleAsync(string roleId);
    }
}
