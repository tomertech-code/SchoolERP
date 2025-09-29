namespace SchoolERP.UI.ViewModelDTO
{
    public class AdminDashboardDto
    {
        // User Info
        public string? FullName { get; set; }
        public string? Role { get; set; }

        // Counts / Statistics
        public int TotalStudents { get; set; }
        public int ActiveStudents { get; set; }
        public int InactiveStudents { get; set; }

        public int TotalTeachers { get; set; }
        public int ActiveTeachers { get; set; }
        public int InactiveTeachers { get; set; }

        public int TotalStaff { get; set; }
        public int ActiveStaff { get; set; }
        public int InactiveStaff { get; set; }

        public int TotalSubjects { get; set; }
        public int ActiveSubjects { get; set; }
        public int InactiveSubjects { get; set; }

        // Optional: Alerts / Notifications
        public List<NotificationDto> Notifications { get; set; } = new List<NotificationDto>();

        // Optional: Attendance
        public AttendanceDto TodayAttendance { get; set; } = new AttendanceDto();

        // Optional: Financial Overview
        public FinancialOverviewDto FinancialOverview { get; set; } = new FinancialOverviewDto();

        // Optional: Upcoming Events
        public List<EventDto> UpcomingEvents { get; set; } = new List<EventDto>();
    }

}
