using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolERP.BLL.Interfaces;
using SchoolERP.BLL.Services;
using SchoolERP.Data.Entities;
using SchoolERP.UI.Helper;
using SchoolERP.UI.ViewModelDTO;

namespace SchoolERP.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IStudentService studentService;
        private readonly ITeacherService teacher;
        private readonly ISubjectService subjectService;

        public HomeController(UserManager<ApplicationUser> userManager,IStudentService studentService,ITeacherService teacher,ISubjectService subjectService)
        {
            _userManager = userManager;
            this.studentService = studentService;
            this.teacher = teacher;
            this.subjectService = subjectService;
        }



        public async Task<IActionResult> AdminDashboard()
        {
            //Login Logins = SessionHelper.GetObjectFromJson<Login>(_httpContextAccessor.HttpContext.Session, "User");
            // Fetch total students
            var studentResponse = await studentService.GetTotalCount();
            var totalStudents = studentResponse.Data;

            // Fetch total teachers
            var teacherCountResponse = await teacher.GetTotalTeacherCount();
            var totalTeachers = teacherCountResponse.Data;

            // Fetch active/deactive teachers
            var teacherStatusResponse = await teacher.GetActiveAndDeactiveTeachers();
            var activeTeachers = teacherStatusResponse.Data.Active;
            var deactiveTeachers = teacherStatusResponse.Data.Deactive;

            // Fetch total subjects
            var subjectResponse = await subjectService.GetTotalSubjectCount();
            var totalSubjects = subjectResponse.Data;

            // Session info
            var fullName = SessionHelper.GetString(HttpContext.Session, "FullName");
            var role = SessionHelper.GetString(HttpContext.Session, "Role");

            // Fill DTO
            var dto = new AdminDashboardDto
            {
                FullName = fullName,
                Role = role,
                TotalStudents = totalStudents,
                TotalTeachers = totalTeachers,
                ActiveTeachers = activeTeachers,
                InactiveStudents = deactiveTeachers,
                TotalSubjects = totalSubjects,
                TotalStaff = 10
            };

            return View(dto);
        }

        public IActionResult TeacherDashboard() => View();
        public IActionResult StudentDashboard() => View();
        public IActionResult ParentDashboard() => View();
    }
}