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
    public class SectionService : ISectionService
    {
        private readonly SchoolERPDbContext _context;

        public SectionService(SchoolERPDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Section>> GetAllSectionsAsync()
        {
            return await _context.Sections.Include(s => s.Class).ToListAsync();
        }

        public async Task<Section> GetSectionByIdAsync(int id)
        {
            return await _context.Sections.Include(s => s.Class).FirstOrDefaultAsync(s => s.SectionId == id);
        }

        public async Task AddSectionAsync(Section section)
        {
            _context.Sections.Add(section);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSectionAsync(Section section)
        {
            _context.Sections.Update(section);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSectionAsync(int id)
        {
            var section = await _context.Sections.FindAsync(id);
            if (section != null)
            {
                _context.Sections.Remove(section);
                await _context.SaveChangesAsync();
            }
        }
    }
}
