using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolERP.Common.Constants;
using SchoolERP.Data.Entities;

namespace SchoolERP.BLL.Interfaces
{
    public interface IExamService
    {
        Task<ApiResponse<IEnumerable<Exam>>> GetAllAsync();
        Task<ApiResponse<Exam>> GetByIdAsync(int id);
        Task<ApiResponse<bool>> AddAsync(Exam exam);
        Task<ApiResponse<bool>> UpdateAsync(Exam exam);
        Task<ApiResponse<bool>> DeleteAsync(int id);
    }
}
