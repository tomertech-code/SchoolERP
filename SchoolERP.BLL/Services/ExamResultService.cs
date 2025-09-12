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
    public class ExamResultService : IExamResultService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExamResultService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<IEnumerable<ExamResult>>> GetAllAsync()
        {
            var results = await _unitOfWork.Repository<ExamResult>().GetAllAsync();
            return ApiResponse<IEnumerable<ExamResult>>.Ok(results);
        }

        public async Task<ApiResponse<ExamResult>> GetByIdAsync(int id)
        {
            var result = await _unitOfWork.Repository<ExamResult>().GetByIdAsync(id);
            if (result == null) return ApiResponse<ExamResult>.Fail("Result not found");
            return ApiResponse<ExamResult>.Ok(result);
        }

        public async Task<ApiResponse<bool>> AddAsync(ExamResult examResult)
        {
            await _unitOfWork.Repository<ExamResult>().AddAsync(examResult);
            await _unitOfWork.SaveChangesAsync();
            return ApiResponse<bool>.Ok(true, "Result added successfully");
        }

        public async Task<ApiResponse<bool>> UpdateAsync(ExamResult examResult)
        {
            _unitOfWork.Repository<ExamResult>().Update(examResult);
            await _unitOfWork.SaveChangesAsync();
            return ApiResponse<bool>.Ok(true, "Result updated successfully");
        }

        public async Task<ApiResponse<bool>> DeleteAsync(int id)
        {
            var result = await _unitOfWork.Repository<ExamResult>().GetByIdAsync(id);
            if (result == null) return ApiResponse<bool>.Fail("Result not found");
            _unitOfWork.Repository<ExamResult>().Remove(result);
            await _unitOfWork.SaveChangesAsync();
            return ApiResponse<bool>.Ok(true, "Result deleted successfully");
        }

        public async Task<ApiResponse<IEnumerable<ExamResult>>> GetResultsByExamAsync(int examId)
        {
            var results = await _unitOfWork.Repository<ExamResult>().FindAsync(r => r.ExamId == examId);
            return ApiResponse<IEnumerable<ExamResult>>.Ok(results);
        }

        public async Task<ApiResponse<IEnumerable<ExamResult>>> GetResultsByStudentAsync(int studentId)
        {
            var results = await _unitOfWork.Repository<ExamResult>().FindAsync(r => r.StudentId == studentId);
            return ApiResponse<IEnumerable<ExamResult>>.Ok(results);
        }
    }
}
