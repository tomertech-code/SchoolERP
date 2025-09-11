using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERP.Common.Constants
{
    public enum UserRole
    {
        Admin,
        Teacher,
        Student,
        Parent
    }

    public enum ComplaintStatus
    {
        Pending,
        InProgress,
        Resolved,
        Rejected
    }

    public enum AttendanceStatus
    {
        Present,
        Absent,
        Leave
    }
}
