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
    public class PtmService : IPtmService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PtmService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<IEnumerable<Ptm>>> GetAllAsync()
        {
            var ptms = await _unitOfWork.Repository<Ptm>().GetAllAsync();
            return ApiResponse<IEnumerable<Ptm>>.Ok(ptms);
        }

        public async Task<ApiResponse<Ptm>> GetByIdAsync(int id)
        {
            var ptm = await _unitOfWork.Repository<Ptm>().GetByIdAsync(id);
            if (ptm == null) return ApiResponse<Ptm>.Fail("PTM not found");
            return ApiResponse<Ptm>.Ok(ptm);
        }

        public async Task<ApiResponse<bool>> AddAsync(Ptm ptm)
        {
            await _unitOfWork.Repository<Ptm>().AddAsync(ptm);
            await _unitOfWork.SaveChangesAsync();
            return ApiResponse<bool>.Ok(true, "PTM created successfully");
        }

        public async Task<ApiResponse<bool>> UpdateAsync(Ptm ptm)
        {
            _unitOfWork.Repository<Ptm>().Update(ptm);
            await _unitOfWork.SaveChangesAsync();
            return ApiResponse<bool>.Ok(true, "PTM updated successfully");
        }

        public async Task<ApiResponse<bool>> DeleteAsync(int id)
        {
            var ptm = await _unitOfWork.Repository<Ptm>().GetByIdAsync(id);
            if (ptm == null) return ApiResponse<bool>.Fail("PTM not found");

            _unitOfWork.Repository<Ptm>().Remove(ptm);
            await _unitOfWork.SaveChangesAsync();
            return ApiResponse<bool>.Ok(true, "PTM deleted successfully");
        }
    }
}
