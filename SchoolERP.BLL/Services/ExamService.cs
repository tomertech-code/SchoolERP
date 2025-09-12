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
    public class ExamService : IExamService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExamService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<IEnumerable<Exam>>> GetAllAsync()
        {
            var exams = await _unitOfWork.Repository<Exam>().GetAllAsync();
            return ApiResponse<IEnumerable<Exam>>.Ok(exams);
        }

        public async Task<ApiResponse<Exam>> GetByIdAsync(int id)
        {
            var exam = await _unitOfWork.Repository<Exam>().GetByIdAsync(id);
            if (exam == null) return ApiResponse<Exam>.Fail("Exam not found");
            return ApiResponse<Exam>.Ok(exam);
        }

        public async Task<ApiResponse<bool>> AddAsync(Exam exam)
        {
            await _unitOfWork.Repository<Exam>().AddAsync(exam);
            await _unitOfWork.SaveChangesAsync();
            return ApiResponse<bool>.Ok(true, "Exam added successfully");
        }

        public async Task<ApiResponse<bool>> UpdateAsync(Exam exam)
        {
            _unitOfWork.Repository<Exam>().Update(exam);
            await _unitOfWork.SaveChangesAsync();
            return ApiResponse<bool>.Ok(true, "Exam updated successfully");
        }

        public async Task<ApiResponse<bool>> DeleteAsync(int id)
        {
            var exam = await _unitOfWork.Repository<Exam>().GetByIdAsync(id);
            if (exam == null) return ApiResponse<bool>.Fail("Exam not found");
            _unitOfWork.Repository<Exam>().Remove(exam);
            await _unitOfWork.SaveChangesAsync();
            return ApiResponse<bool>.Ok(true, "Exam deleted successfully");
        }
    }
}
