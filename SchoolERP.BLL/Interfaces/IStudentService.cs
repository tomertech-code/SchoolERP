using SchoolERP.Common.Constants;
using SchoolERP.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolERP.BLL.Interfaces
{
    public interface IStudentService
    {
        Task<ApiResponse<IEnumerable<Student>>> GetAllStudentsAsync();
        Task<ApiResponse<Student>> GetStudentByIdAsync(int id);
        Task<ApiResponse<bool>> AddStudentAsync(Student student);
        Task<ApiResponse<bool>> UpdateStudentAsync(Student student);
        Task<ApiResponse<bool>> DeleteStudentAsync(int id);
    }
}
