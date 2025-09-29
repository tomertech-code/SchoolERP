namespace SchoolERP.UI.ViewModelDTO
{
    public class NotificationDto
    {
        public string StudentName { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}
