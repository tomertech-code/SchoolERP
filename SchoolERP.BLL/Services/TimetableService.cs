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
    public class TimetableService : ITimetableService
    {
        private readonly SchoolERPDbContext _context;

        public TimetableService(SchoolERPDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Timetable>> GetAllTimetablesAsync()
        {
            return await _context.Timetables
                .Include(t => t.Class)
                .Include(t => t.Section)
                .Include(t => t.Subject)
                .Include(t => t.Teacher)
                .Include(t => t.Period)
                .ToListAsync();
        }

        public async Task<Timetable> GetTimetableByIdAsync(int timetableId)
        {
            return await _context.Timetables
                .Include(t => t.Class)
                .Include(t => t.Section)
                .Include(t => t.Subject)
                .Include(t => t.Teacher)
                .Include(t => t.Period)
                .FirstOrDefaultAsync(t => t.TimetableId == timetableId);
        }

        public async Task<IEnumerable<Timetable>> GetTimetableByClassAsync(int classId)
        {
            return await _context.Timetables
                .Include(t => t.Class)
                .Include(t => t.Section)
                .Include(t => t.Subject)
                .Include(t => t.Teacher)
                .Include(t => t.Period)
                .Where(t => t.ClassId == classId)
                .ToListAsync();
        }

        public async Task AddTimetableAsync(Timetable timetable)
        {
            _context.Timetables.Add(timetable);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTimetableAsync(Timetable timetable)
        {
            _context.Timetables.Update(timetable);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTimetableAsync(int timetableId)
        {
            var timetable = await _context.Timetables.FindAsync(timetableId);
            if (timetable != null)
            {
                _context.Timetables.Remove(timetable);
                await _context.SaveChangesAsync();
            }
        }
    }

}