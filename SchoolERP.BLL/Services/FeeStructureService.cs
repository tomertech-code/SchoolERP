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
    public class FeeStructureService : IFeeStructureService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FeeStructureService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<IEnumerable<FeeStructure>>> GetAllAsync()
        {
            var data = await _unitOfWork.Repository<FeeStructure>().GetAllAsync();
            return ApiResponse<IEnumerable<FeeStructure>>.Ok(data);
        }

        public async Task<ApiResponse<FeeStructure>> GetByIdAsync(int id)
        {
            var structure = await _unitOfWork.Repository<FeeStructure>().GetByIdAsync(id);
            if (structure == null) return ApiResponse<FeeStructure>.Fail("Not found");
            return ApiResponse<FeeStructure>.Ok(structure);
        }

        public async Task<ApiResponse<bool>> AddAsync(FeeStructure structure)
        {
            await _unitOfWork.Repository<FeeStructure>().AddAsync(structure);
            await _unitOfWork.SaveChangesAsync();
            return ApiResponse<bool>.Ok(true, "Fee Structure added");
        }

        public async Task<ApiResponse<bool>> UpdateAsync(FeeStructure structure)
        {
            _unitOfWork.Repository<FeeStructure>().Update(structure);
            await _unitOfWork.SaveChangesAsync();
            return ApiResponse<bool>.Ok(true, "Fee Structure updated");
        }

        public async Task<ApiResponse<bool>> DeleteAsync(int id)
        {
            var structure = await _unitOfWork.Repository<FeeStructure>().GetByIdAsync(id);
            if (structure == null) return ApiResponse<bool>.Fail("Not found");
            _unitOfWork.Repository<FeeStructure>().Remove(structure);
            await _unitOfWork.SaveChangesAsync();
            return ApiResponse<bool>.Ok(true, "Fee Structure deleted");
        }
    }
    }
