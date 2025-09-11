using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolERP.BLL.Interfaces;
using SchoolERP.Common.Constants;
using SchoolERP.Data.Entities;
using SchoolERP.Data.Interfaces;

namespace SchoolERP.Business.Services
    {
        public class StudentComplaintService : IStudentComplaintService
        {
            private readonly IUnitOfWork _unitOfWork;

            public StudentComplaintService(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<ApiResponse<IEnumerable<StudentComplaint>>> GetAllComplaintsAsync()
            {
                var complaints = await _unitOfWork.Repository<StudentComplaint>().GetAllAsync();
                return ApiResponse<IEnumerable<StudentComplaint>>.Ok(complaints);
            }

            public async Task<ApiResponse<StudentComplaint>> GetComplaintByIdAsync(int id)
            {
                var complaint = await _unitOfWork.Repository<StudentComplaint>().GetByIdAsync(id);
                if (complaint == null)
                    return ApiResponse<StudentComplaint>.Fail("Complaint not found");
                return ApiResponse<StudentComplaint>.Ok(complaint);
            }

            public async Task<ApiResponse<bool>> AddComplaintAsync(StudentComplaint complaint)
            {
                await _unitOfWork.Repository<StudentComplaint>().AddAsync(complaint);
                await _unitOfWork.SaveChangesAsync();
                return ApiResponse<bool>.Ok(true, "Complaint added successfully");
            }

            public async Task<ApiResponse<bool>> UpdateComplaintAsync(StudentComplaint complaint)
            {
                _unitOfWork.Repository<StudentComplaint>().Update(complaint);
                await _unitOfWork.SaveChangesAsync();
                return ApiResponse<bool>.Ok(true, "Complaint updated successfully");
            }

            public async Task<ApiResponse<bool>> DeleteComplaintAsync(int id)
            {
                var complaint = await _unitOfWork.Repository<StudentComplaint>().GetByIdAsync(id);
                if (complaint == null)
                    return ApiResponse<bool>.Fail("Complaint not found");

                _unitOfWork.Repository<StudentComplaint>().Remove(complaint);
                await _unitOfWork.SaveChangesAsync();
                return ApiResponse<bool>.Ok(true, "Complaint deleted successfully");
            }
        }
    }
