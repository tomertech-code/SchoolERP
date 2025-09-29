using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolERP.Common.Constants;
using SchoolERP.Data.Entities;

namespace SchoolERP.BLL.Interfaces
{
    public interface ITeacherService
    {
        Task<ApiResponse<IEnumerable<Teacher>>> GetAllTeachersAsync();
        Task<ApiResponse<Teacher>> GetTeacherByIdAsync(int id);
        Task<ApiResponse<bool>> AddTeacherAsync(Teacher teacher);
        Task<ApiResponse<bool>> UpdateTeacherAsync(Teacher teacher);
        Task<ApiResponse<bool>> DeleteTeacherAsync(int id);
        Task<ApiResponse<int>> GetTotalTeacherCount();
        Task<ApiResponse<(int Active, int Deactive)>> GetActiveAndDeactiveTeachers();
    }
}
