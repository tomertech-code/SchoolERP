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
    public class TransportService : ITransportService
    {
        private readonly SchoolERPDbContext _context;

        public TransportService(SchoolERPDbContext context)
        {
            _context = context;
        }

        // ---------------- BUS MANAGEMENT ----------------
        public async Task<IEnumerable<Bus>> GetAllBusesAsync()
        {
            return _context.Buses.ToList();
        }

        public async Task<Bus> GetBusByIdAsync(int id)
        {
            return await _context.Buses.FindAsync(id);
        }

        public async Task<Bus> CreateBusAsync(Bus bus)
        {
            _context.Buses.Add(bus);
            await _context.SaveChangesAsync();
            return bus;
        }

        public async Task<Bus> UpdateBusAsync(Bus bus)
        {
            _context.Buses.Update(bus);
            await _context.SaveChangesAsync();
            return bus;
        }

        public async Task<bool> DeleteBusAsync(int id)
        {
            var bus = await _context.Buses.FindAsync(id);
            if (bus == null) return false;

            _context.Buses.Remove(bus);
            await _context.SaveChangesAsync();
            return true;
        }

        // ---------------- STUDENT TRANSPORT ----------------
        public async Task<IEnumerable<StudentTransport>> GetAllStudentTransportsAsync()
        {
            return await _context.StudentTransports
                .Include(st => st.Student)
                .Include(st => st.Bus)
                .ToListAsync();
        }

        public async Task<StudentTransport> AssignStudentToBusAsync(StudentTransport mapping)
        {
            _context.StudentTransports.Add(mapping);
            await _context.SaveChangesAsync();
            return mapping;
        }

        public async Task<bool> RemoveStudentFromBusAsync(int id)
        {
            var mapping = await _context.StudentTransports.FindAsync(id);
            if (mapping == null) return false;

            _context.StudentTransports.Remove(mapping);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}