using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERP.Data.Entities
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsRead { get; set; }

        // Target user (Student/Parent/Teacher/All)
        public string TargetRole { get; set; } = string.Empty;
        public string? TargetUserId { get; set; } // for specific user
    }
}
