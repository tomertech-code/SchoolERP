using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolERP.Data.Entities;

namespace SchoolERP.BLL.Interfaces
{
    public interface ITimetableService
    {
        Task<IEnumerable<Timetable>> GetAllTimetablesAsync();
        Task<Timetable> GetTimetableByIdAsync(int timetableId);
        Task<IEnumerable<Timetable>> GetTimetableByClassAsync(int classId);
        Task AddTimetableAsync(Timetable timetable);
        Task UpdateTimetableAsync(Timetable timetable);
        Task DeleteTimetableAsync(int timetableId);
    }
}
