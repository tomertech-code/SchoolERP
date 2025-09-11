using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolERP.Common.Constants;
using SchoolERP.Data.Entities;

namespace SchoolERP.BLL.Interfaces
{
    public interface IStudentComplaintService
    {
        Task<ApiResponse<IEnumerable<StudentComplaint>>> GetAllComplaintsAsync();
        Task<ApiResponse<StudentComplaint>> GetComplaintByIdAsync(int id);
        Task<ApiResponse<bool>> AddComplaintAsync(StudentComplaint complaint);
        Task<ApiResponse<bool>> UpdateComplaintAsync(StudentComplaint complaint);
        Task<ApiResponse<bool>> DeleteComplaintAsync(int id);
    }
}
