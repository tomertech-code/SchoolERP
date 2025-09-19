using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolERP.BLL.Interfaces;
using SchoolERP.Data.DbContext;
using SchoolERP.Data.Entities;

namespace SchoolERP.BLL.Services
{
    public class StaffService : IStaffService
    {
        private readonly SchoolERPDbContext _context;

        public StaffService(SchoolERPDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Staff>> GetAllAsync()
        {
            return await _context.Staff
                .Include(s => s.Payrolls) // optional: eager load payroll
                .ToListAsync();
        }

        public async Task<Staff> GetByIdAsync(int id)
        {
            return await _context.Staff
                .Include(s => s.Payrolls)
                .FirstOrDefaultAsync(s => s.StaffId == id);
        }

        public async Task<Staff> CreateAsync(Staff staff)
        {
            _context.Staff.Add(staff);
            await _context.SaveChangesAsync();
            return staff;
        }

        public async Task<Staff> UpdateAsync(Staff staff)
        {
            _context.Staff.Update(staff);
            await _context.SaveChangesAsync();
            return staff;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var staff = await _context.Staff.FindAsync(id);
            if (staff == null) return false;

            _context.Staff.Remove(staff);
            await _context.SaveChangesAsync();
            return true;
        }

        // Payroll
        public async Task<Payroll> GetPayrollAsync(int staffId)
        {
            return await _context.Payrolls.FirstOrDefaultAsync(p => p.StaffId == staffId);
        }

        public async Task<Payroll> AddOrUpdatePayrollAsync(Payroll payroll)
        {
            var existing = await _context.Payrolls.FirstOrDefaultAsync(p => p.StaffId == payroll.StaffId);
            if (existing == null)
            {
                _context.Payrolls.Add(payroll);
            }
            else
            {
                existing.BasicSalary = payroll.BasicSalary;
                existing.Allowances = payroll.Allowances;
                existing.Deductions = payroll.Deductions;
                existing.NetSalary = payroll.NetSalary;
                _context.Payrolls.Update(existing);
            }
            await _context.SaveChangesAsync();
            return payroll;
        }
    }

}
