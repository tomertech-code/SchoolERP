using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolERP.Common.Constants;
using SchoolERP.Data.Entities;

namespace SchoolERP.BLL.Interfaces
{
    public interface INotificationService
    {
        Task<ApiResponse<IEnumerable<Notification>>> GetAllAsync();
        Task<ApiResponse<Notification>> GetByIdAsync(int id);
        Task<ApiResponse<Notification>> AddAsync(Notification notification);
        Task<ApiResponse<Notification>> UpdateAsync(Notification notification);
        Task<ApiResponse<bool>> DeleteAsync(int id);

        Task<ApiResponse<bool>> SendNotificationAsync(string title, string message, string role, string? userId = null);
    }
}
