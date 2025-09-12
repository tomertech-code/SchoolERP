using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolERP.Common.Constants;
using SchoolERP.Data.Entities;

namespace SchoolERP.BLL.Interfaces
{
    public interface IExamResultService
    {
        Task<ApiResponse<IEnumerable<ExamResult>>> GetAllAsync();
        Task<ApiResponse<ExamResult>> GetByIdAsync(int id);
        Task<ApiResponse<bool>> AddAsync(ExamResult examResult);
        Task<ApiResponse<bool>> UpdateAsync(ExamResult examResult);
        Task<ApiResponse<bool>> DeleteAsync(int id);
        Task<ApiResponse<IEnumerable<ExamResult>>> GetResultsByExamAsync(int examId);
        Task<ApiResponse<IEnumerable<ExamResult>>> GetResultsByStudentAsync(int studentId);
    }
}
