using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolERP.Data.Entities;

namespace SchoolERP.BLL.Interfaces
{
    public interface IStaffService
    {
        Task<IEnumerable<Staff>> GetAllAsync();
        Task<Staff> GetByIdAsync(int id);
        Task<Staff> CreateAsync(Staff staff);
        Task<Staff> UpdateAsync(Staff staff);
        Task<bool> DeleteAsync(int id);

        // Payroll-related
        Task<Payroll> GetPayrollAsync(int staffId);
        Task<Payroll> AddOrUpdatePayrollAsync(Payroll payroll);
    }
}
