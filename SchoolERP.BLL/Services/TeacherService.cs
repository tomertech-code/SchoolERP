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
    public class TeacherService : ITeacherService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeacherService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<IEnumerable<Teacher>>> GetAllTeachersAsync()
        {
            var teachers = await _unitOfWork.Repository<Teacher>()
                .GetAllWithIncludeAsync(t => t.Subject, t => t.User);

            return ApiResponse<IEnumerable<Teacher>>.Ok(teachers);
        }

        public async Task<ApiResponse<Teacher>> GetTeacherByIdAsync(int id)
        {
            var teacher = await _unitOfWork.Repository<Teacher>()
                .GetByIdWithIncludeAsync(t => t.TeacherId == id, t => t.Subject, t => t.User);

            if (teacher == null)
                return ApiResponse<Teacher>.Fail("Teacher not found");

            return ApiResponse<Teacher>.Ok(teacher);
        }
        public async Task<ApiResponse<bool>> AddTeacherAsync(Teacher teacher)
        {
            await _unitOfWork.Repository<Teacher>().AddAsync(teacher);
            await _unitOfWork.SaveChangesAsync();
            return ApiResponse<bool>.Ok(true, "Teacher added successfully");
        }

        public async Task<ApiResponse<bool>> UpdateTeacherAsync(Teacher teacher)
        {
            _unitOfWork.Repository<Teacher>().Update(teacher);
            await _unitOfWork.SaveChangesAsync();
            return ApiResponse<bool>.Ok(true, "Teacher updated successfully");
        }

        public async Task<ApiResponse<bool>> DeleteTeacherAsync(int id)
        {
            var teacher = await _unitOfWork.Repository<Teacher>().GetByIdAsync(id);
            if (teacher == null)
                return ApiResponse<bool>.Fail("Teacher not found");

            _unitOfWork.Repository<Teacher>().Remove(teacher);
            await _unitOfWork.SaveChangesAsync();
            return ApiResponse<bool>.Ok(true, "Teacher deleted successfully");
        }
    }
}
