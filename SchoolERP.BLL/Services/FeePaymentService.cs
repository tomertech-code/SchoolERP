using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolERP.BLL.Interfaces;
using SchoolERP.Common.Constants;
using SchoolERP.Data.Entities;
using SchoolERP.Data.Interfaces;

namespace SchoolERP.BLL.Services
{
    public class FeePaymentService : IFeePaymentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FeePaymentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<IEnumerable<FeePayment>>> GetAllAsync()
        {
            var data = await _unitOfWork.Repository<FeePayment>().GetAllAsync();
            return ApiResponse<IEnumerable<FeePayment>>.Ok(data);
        }

        public async Task<ApiResponse<FeePayment>> GetByIdAsync(int id)
        {
            var payment = await _unitOfWork.Repository<FeePayment>().GetByIdAsync(id);
            if (payment == null) return ApiResponse<FeePayment>.Fail("Not found");
            return ApiResponse<FeePayment>.Ok(payment);
        }

        public async Task<ApiResponse<bool>> AddAsync(FeePayment payment)
        {
            await _unitOfWork.Repository<FeePayment>().AddAsync(payment);
            await _unitOfWork.SaveChangesAsync();
            return ApiResponse<bool>.Ok(true, "Fee Payment added");
        }

        public async Task<ApiResponse<bool>> UpdateAsync(FeePayment payment)
        {
            _unitOfWork.Repository<FeePayment>().Update(payment);
            await _unitOfWork.SaveChangesAsync();
            return ApiResponse<bool>.Ok(true, "Fee Payment updated");
        }

        public async Task<ApiResponse<bool>> DeleteAsync(int id)
        {
            var payment = await _unitOfWork.Repository<FeePayment>().GetByIdAsync(id);
            if (payment == null) return ApiResponse<bool>.Fail("Not found");
            _unitOfWork.Repository<FeePayment>().Remove(payment);
            await _unitOfWork.SaveChangesAsync();
            return ApiResponse<bool>.Ok(true, "Fee Payment deleted");
        }
    }
}
