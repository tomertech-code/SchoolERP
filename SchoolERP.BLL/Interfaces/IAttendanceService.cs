using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolERP.Common.Constants;
using SchoolERP.Data.Entities;

namespace SchoolERP.BLL.Interfaces
{
    public interface IAttendanceService
    {
        Task<ApiResponse<IEnumerable<Attendance>>> GetAllAsync();
        Task<ApiResponse<Attendance>> GetByIdAsync(int id);
        Task<ApiResponse<bool>> AddAsync(Attendance attendance);
        Task<ApiResponse<bool>> UpdateAsync(Attendance attendance);
        Task<ApiResponse<bool>> DeleteAsync(int id);
    }
}
