using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolERP.Data.Entities;

namespace SchoolERP.BLL.Interfaces
{
    public interface IClassService
    {
        Task<IEnumerable<Class>> GetAllClassesAsync();
        Task<Class> GetClassByIdAsync(int id);
        Task AddClassAsync(Class cls);
        Task UpdateClassAsync(Class cls);
        Task DeleteClassAsync(int id);
    }
}
