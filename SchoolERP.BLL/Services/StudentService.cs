using System;
using System.Collections;
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
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<IEnumerable<Student>>> GetAllStudentsAsync()
        {
            var students = await _unitOfWork.Repository<Student>().GetAllAsync();
            return ApiResponse<IEnumerable<Student>>.Ok(students);
        }

        public async Task<ApiResponse<Student>> GetStudentByIdAsync(int id)
        {
            var student = await _unitOfWork.Repository<Student>().GetByIdAsync(id);
            if (student == null)
                return ApiResponse<Student>.Fail("Student not found");
            return ApiResponse<Student>.Ok(student);
        }

        public async Task<ApiResponse<bool>> AddStudentAsync(Student student)
        {
            await _unitOfWork.Repository<Student>().AddAsync(student);
            await _unitOfWork.SaveChangesAsync();
            return ApiResponse<bool>.Ok(true, "Student added successfully");
        }

        public async Task<ApiResponse<bool>> UpdateStudentAsync(Student student)
        {
            _unitOfWork.Repository<Student>().Update(student);
            await _unitOfWork.SaveChangesAsync();
            return ApiResponse<bool>.Ok(true, "Student updated successfully");
        }

        public async Task<ApiResponse<bool>> DeleteStudentAsync(int id)
        {
            var student = await _unitOfWork.Repository<Student>().GetByIdAsync(id);
            if (student == null)
                return ApiResponse<bool>.Fail("Student not found");

            _unitOfWork.Repository<Student>().Remove(student);
            await _unitOfWork.SaveChangesAsync();
            return ApiResponse<bool>.Ok(true, "Student deleted successfully");
        }

        public Task<IEnumerable> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
