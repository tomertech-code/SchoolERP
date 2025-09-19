using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolERP.BLL.Interfaces;
using SchoolERP.Common.Constants;
using SchoolERP.Data.DbContext;
using SchoolERP.Data.Entities;

namespace SchoolERP.BLL.Services
{
    public class NotificationService : INotificationService
    {
        private readonly SchoolERPDbContext _context;

        public NotificationService(SchoolERPDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse<IEnumerable<Notification>>> GetAllAsync()
        {
            //var list = await _context.Notifications.ToListAsync();
            var list =  _context.Notifications.ToList();
            return new ApiResponse<IEnumerable<Notification>>(true, "Fetched successfully", list);
        }

        public async Task<ApiResponse<Notification>> GetByIdAsync(int id)
        {
            var entity = await _context.Notifications.FindAsync(id);
            if (entity == null) return new ApiResponse<Notification>(false, "Not found");
            return new ApiResponse<Notification>(true, "Fetched successfully", entity);
        }

        public async Task<ApiResponse<Notification>> AddAsync(Notification notification)
        {
            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync();
            return new ApiResponse<Notification>(true, "Notification created", notification);
        }

        public async Task<ApiResponse<Notification>> UpdateAsync(Notification notification)
        {
            _context.Notifications.Update(notification);
            await _context.SaveChangesAsync();
            return new ApiResponse<Notification>(true, "Notification updated", notification);
        }

        public async Task<ApiResponse<bool>> DeleteAsync(int id)
        {
            var entity = await _context.Notifications.FindAsync(id);
            if (entity == null) return new ApiResponse<bool>(false, "Not found");

            _context.Notifications.Remove(entity);
            await _context.SaveChangesAsync();
            return new ApiResponse<bool>(true, "Deleted successfully", true);
        }

        public async Task<ApiResponse<bool>> SendNotificationAsync(string title, string message, string role, string? userId = null)
        {
            var notification = new Notification
            {
                Title = title,
                Message = message,
                TargetRole = role,
                TargetUserId = userId
            };

            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync();

            // TODO: integrate with Email/SMS gateway here

            return new ApiResponse<bool>(true, "Notification sent successfully", true);
        }
    }
};