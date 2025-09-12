using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolERP.Common.Constants;
using SchoolERP.Data.Entities;

namespace SchoolERP.BLL.Interfaces
{
    public interface IFeePaymentService
    {
        Task<ApiResponse<IEnumerable<FeePayment>>> GetAllAsync();
        Task<ApiResponse<FeePayment>> GetByIdAsync(int id);
        Task<ApiResponse<bool>> AddAsync(FeePayment payment);
        Task<ApiResponse<bool>> UpdateAsync(FeePayment payment);
        Task<ApiResponse<bool>> DeleteAsync(int id);
    }
}
