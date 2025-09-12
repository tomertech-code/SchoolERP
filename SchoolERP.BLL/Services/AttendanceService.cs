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
    public class AttendanceService : IAttendanceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AttendanceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<IEnumerable<Attendance>>> GetAllAsync()
        {
            var records = await _unitOfWork.Repository<Attendance>().GetAllAsync();
            return ApiResponse<IEnumerable<Attendance>>.Ok(records);
        }

        public async Task<ApiResponse<Attendance>> GetByIdAsync(int id)
        {
            var record = await _unitOfWork.Repository<Attendance>().GetByIdAsync(id);
            if (record == null) return ApiResponse<Attendance>.Fail("Attendance not found");
            return ApiResponse<Attendance>.Ok(record);
        }

        public async Task<ApiResponse<bool>> AddAsync(Attendance attendance)
        {
            await _unitOfWork.Repository<Attendance>().AddAsync(attendance);
            await _unitOfWork.SaveChangesAsync();
            return ApiResponse<bool>.Ok(true, "Attendance added successfully");
        }

        public async Task<ApiResponse<bool>> UpdateAsync(Attendance attendance)
        {
            _unitOfWork.Repository<Attendance>().Update(attendance);
            await _unitOfWork.SaveChangesAsync();
            return ApiResponse<bool>.Ok(true, "Attendance updated successfully");
        }

        public async Task<ApiResponse<bool>> DeleteAsync(int id)
        {
            var record = await _unitOfWork.Repository<Attendance>().GetByIdAsync(id);
            if (record == null) return ApiResponse<bool>.Fail("Attendance not found");

            _unitOfWork.Repository<Attendance>().Remove(record);
            await _unitOfWork.SaveChangesAsync();
            return ApiResponse<bool>.Ok(true, "Attendance deleted successfully");
        }
    }
}
