using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolERP.Data.Entities;

namespace SchoolERP.BLL.Interfaces
{
    public interface ITransportService
    {
        // Bus management
        Task<IEnumerable<Bus>> GetAllBusesAsync();
        Task<Bus> GetBusByIdAsync(int id);
        Task<Bus> CreateBusAsync(Bus bus);
        Task<Bus> UpdateBusAsync(Bus bus);
        Task<bool> DeleteBusAsync(int id);

        // Student transport mapping
        Task<IEnumerable<StudentTransport>> GetAllStudentTransportsAsync();
        Task<StudentTransport> AssignStudentToBusAsync(StudentTransport mapping);
        Task<bool> RemoveStudentFromBusAsync(int id);
    }
}
