using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolERP.Common.Constants;
using SchoolERP.Data.Entities;

namespace SchoolERP.BLL.Interfaces
{
    public interface IFeeStructureService
    {
        Task<ApiResponse<IEnumerable<FeeStructure>>> GetAllAsync();
        Task<ApiResponse<FeeStructure>> GetByIdAsync(int id);
        Task<ApiResponse<bool>> AddAsync(FeeStructure structure);
        Task<ApiResponse<bool>> UpdateAsync(FeeStructure structure);
        Task<ApiResponse<bool>> DeleteAsync(int id);
    }
}
