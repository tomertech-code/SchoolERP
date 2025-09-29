using Microsoft.EntityFrameworkCore;
using SchoolERP.BLL.Interfaces;
using SchoolERP.Common.Constants;
using SchoolERP.Data.DbContext;
using SchoolERP.Data.Entities;
using SchoolERP.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERP.BLL.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly SchoolERPDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public SubjectService(SchoolERPDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Subject>> GetAllSubjectsAsync()
        {
            return await _context.Subjects.Include(s => s.Class).ToListAsync();
        }

        public async Task<Subject> GetSubjectByIdAsync(int id)
        {
            return await _context.Subjects.Include(s => s.Class)
                                          .FirstOrDefaultAsync(s => s.SubjectId == id);
        }

        public async Task AddSubjectAsync(Subject subject)
        {
            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSubjectAsync(Subject subject)
        {
            _context.Subjects.Update(subject);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSubjectAsync(int id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            if (subject != null)
            {
                _context.Subjects.Remove(subject);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<ApiResponse<int>> GetTotalSubjectCount()
        {
            try
            {
                var Subjects = await _unitOfWork.Repository<Subject>().GetAllAsync();
                var totalCount = Subjects.Count();
                return ApiResponse<int>.Ok(totalCount);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
