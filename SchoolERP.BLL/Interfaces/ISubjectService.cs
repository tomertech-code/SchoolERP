using SchoolERP.Common.Constants;
using SchoolERP.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERP.BLL.Interfaces
{
    public interface ISubjectService
    {
        Task<IEnumerable<Subject>> GetAllSubjectsAsync();
        Task<Subject> GetSubjectByIdAsync(int id);
        Task AddSubjectAsync(Subject subject);
        Task UpdateSubjectAsync(Subject subject);
        Task DeleteSubjectAsync(int id);
        Task<ApiResponse<int>> GetTotalSubjectCount();
    }
}
