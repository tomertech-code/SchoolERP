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
    public class ParentService : IParentService
    {
        private readonly SchoolERPDbContext _context;

        public ParentService(SchoolERPDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Parent>> GetAllAsync()
        {
            return  _context.Parents.ToList();
        }

        public async Task<Parent> GetByIdAsync(int id)
        {
            return await _context.Parents
                .Include(p => p.ParentStudents)
                .ThenInclude(ps => ps.Student)
                .FirstOrDefaultAsync(p => p.ParentId == id);
        }

        public async Task<Parent> CreateAsync(Parent parent)
        {
            _context.Parents.Add(parent);
            await _context.SaveChangesAsync();
            return parent;
        }

        public async Task<Parent> UpdateAsync(Parent parent)
        {
            _context.Parents.Update(parent);
            await _context.SaveChangesAsync();
            return parent;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var parent = await _context.Parents.FindAsync(id);
            if (parent == null) return false;

            _context.Parents.Remove(parent);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AssignStudentAsync(int parentId, int studentId)
        {
            var parent = await _context.Parents.FindAsync(parentId);
            var student = await _context.Students.FindAsync(studentId);

            if (parent == null || student == null) return false;

            var link = new ParentStudent
            {
                ParentId = parentId,
                StudentId = studentId
            };

            _context.ParentStudents.Add(link);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Student>> GetChildrenAsync(int parentId)
        {
            return await _context.ParentStudents
                .Where(ps => ps.ParentId == parentId)
                .Select(ps => ps.Student)
                .ToListAsync();
        }
    }

}
