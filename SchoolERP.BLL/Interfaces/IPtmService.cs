using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolERP.Common.Constants;
using SchoolERP.Data.Entities;

namespace SchoolERP.BLL.Interfaces
{
    public interface IPtmService
    {
        Task<ApiResponse<IEnumerable<Ptm>>> GetAllAsync();
        Task<ApiResponse<Ptm>> GetByIdAsync(int id);
        Task<ApiResponse<bool>> AddAsync(Ptm ptm);
        Task<ApiResponse<bool>> UpdateAsync(Ptm ptm);
        Task<ApiResponse<bool>> DeleteAsync(int id);
    }
}
