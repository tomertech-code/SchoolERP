using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolERP.Data.Entities;

namespace SchoolERP.BLL.Interfaces
{
    public interface IParentService
    {
        Task<IEnumerable<Parent>> GetAllAsync();
        Task<Parent> GetByIdAsync(int id);
        Task<Parent> CreateAsync(Parent parent);
        Task<Parent> UpdateAsync(Parent parent);
        Task<bool> DeleteAsync(int id);

        // Linking parent with student(s)
        Task<bool> AssignStudentAsync(int parentId, int studentId);
        Task<IEnumerable<Student>> GetChildrenAsync(int parentId);
    }

}
