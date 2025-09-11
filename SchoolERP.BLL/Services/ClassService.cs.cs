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
    public class ClassService : IClassService
    {
        private readonly SchoolERPDbContext _context;

        public ClassService(SchoolERPDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Class>> GetAllClassesAsync()
        {
            return await _context.Classes.ToListAsync();
        }

        public async Task<Class> GetClassByIdAsync(int id)
        {
            return await _context.Classes.FindAsync(id);
        }

        public async Task AddClassAsync(Class cls)
        {
            _context.Classes.Add(cls);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateClassAsync(Class cls)
        {
            _context.Classes.Update(cls);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClassAsync(int id)
        {
            var cls = await _context.Classes.FindAsync(id);
            if (cls != null)
            {
                _context.Classes.Remove(cls);
                await _context.SaveChangesAsync();
            }
        }
    }
}
