using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolERP.Data.Entities;

namespace SchoolERP.Data.DbContext;
public partial class SchoolERPDbContext : IdentityDbContext<ApplicationUser>
{
    public SchoolERPDbContext(DbContextOptions<SchoolERPDbContext> options) : base(options)
    {
    }

    public virtual DbSet<ActivityLog> ActivityLogs { get; set; }

    public virtual DbSet<Assignment> Assignments { get; set; }

    public virtual DbSet<AssignmentSubmission> AssignmentSubmissions { get; set; }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookIssue> BookIssues { get; set; }

    public virtual DbSet<Bus> Buses { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<ComplaintCategory> ComplaintCategories { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Exam> Exams { get; set; }

    public virtual DbSet<ExamResult> ExamResults { get; set; }

    public virtual DbSet<ExamType> ExamTypes { get; set; }

    public virtual DbSet<FeePayment> FeePayments { get; set; }

    public virtual DbSet<FeeStructure> FeeStructures { get; set; }

    public virtual DbSet<Hostel> Hostels { get; set; }

    public virtual DbSet<HostelAllocation> HostelAllocations { get; set; }

    public virtual DbSet<HostelRoom> HostelRooms { get; set; }

    public virtual DbSet<Notice> Notices { get; set; }

    public virtual DbSet<Parent> Parents { get; set; }

    public virtual DbSet<ParentStudent> ParentStudents { get; set; }

    public virtual DbSet<Payroll> Payrolls { get; set; }

    public virtual DbSet<Period> Periods { get; set; }

    public virtual DbSet<Ptm> Ptms { get; set; }

    public virtual DbSet<Ptmfeedback> Ptmfeedbacks { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Section> Sections { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentComplaint> StudentComplaints { get; set; }

    public virtual DbSet<StudentTransport> StudentTransports { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<TeacherAttendance> TeacherAttendances { get; set; }

    public virtual DbSet<Timetable> Timetables { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ActivityLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__Activity__5E548648D837BC40");

            entity.Property(e => e.ActionDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.User).WithMany(p => p.ActivityLogs).HasConstraintName("FK__ActivityL__UserI__236943A5");
        });

        modelBuilder.Entity<Assignment>(entity =>
        {
            entity.HasKey(e => e.AssignmentId).HasName("PK__Assignme__32499E77ED3A1BF3");

            entity.HasOne(d => d.Class).WithMany(p => p.Assignments).HasConstraintName("FK__Assignmen__Class__7B5B524B");

            entity.HasOne(d => d.Section).WithMany(p => p.Assignments).HasConstraintName("FK__Assignmen__Secti__7C4F7684");

            entity.HasOne(d => d.Subject).WithMany(p => p.Assignments).HasConstraintName("FK__Assignmen__Subje__7D439ABD");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Assignments).HasConstraintName("FK__Assignmen__Teach__7E37BEF6");
        });

        modelBuilder.Entity<AssignmentSubmission>(entity =>
        {
            entity.HasKey(e => e.SubmissionId).HasName("PK__Assignme__449EE12544AEC366");

            entity.HasOne(d => d.Assignment).WithMany(p => p.AssignmentSubmissions).HasConstraintName("FK__Assignmen__Assig__01142BA1");

            entity.HasOne(d => d.Student).WithMany(p => p.AssignmentSubmissions).HasConstraintName("FK__Assignmen__Stude__02084FDA");
        });

        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(e => e.AttendanceId).HasName("PK__Attendan__8B69261C26967CC8");

            entity.HasOne(d => d.Student).WithMany(p => p.Attendances).HasConstraintName("FK__Attendanc__Stude__5441852A");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PK__Books__3DE0C20783FE5393");
        });

        modelBuilder.Entity<BookIssue>(entity =>
        {
            entity.HasKey(e => e.IssueId).HasName("PK__BookIssu__6C861604DA26F8EF");

            entity.HasOne(d => d.Book).WithMany(p => p.BookIssues).HasConstraintName("FK__BookIssue__BookI__114A936A");

            entity.HasOne(d => d.Student).WithMany(p => p.BookIssues).HasConstraintName("FK__BookIssue__Stude__123EB7A3");
        });

        modelBuilder.Entity<Bus>(entity =>
        {
            entity.HasKey(e => e.BusId).HasName("PK__Buses__6A0F60B57157FBAC");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PK__Classes__CB1927C03BE7400D");
        });

        modelBuilder.Entity<ComplaintCategory>(entity =>
        {
            entity.HasKey(e => e.ComplaintCategoryId).HasName("PK__Complain__F5043A62864D97D7");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__Events__7944C81084E15080");
        });

        modelBuilder.Entity<Exam>(entity =>
        {
            entity.HasKey(e => e.ExamId).HasName("PK__Exams__297521C727D286E1");

            entity.HasOne(d => d.Class).WithMany(p => p.Exams).HasConstraintName("FK__Exams__ClassId__5BE2A6F2");

            entity.HasOne(d => d.ExamType).WithMany(p => p.Exams).HasConstraintName("FK_Exams_ExamTypes");
        });

        modelBuilder.Entity<ExamResult>(entity =>
        {
            entity.HasKey(e => e.ResultId).HasName("PK__ExamResu__9769020873A215B9");

            entity.HasOne(d => d.Exam).WithMany(p => p.ExamResults).HasConstraintName("FK__ExamResul__ExamI__5EBF139D");

            entity.HasOne(d => d.Student).WithMany(p => p.ExamResults).HasConstraintName("FK__ExamResul__Stude__5FB337D6");

            entity.HasOne(d => d.Subject).WithMany(p => p.ExamResults).HasConstraintName("FK__ExamResul__Subje__60A75C0F");
        });

        modelBuilder.Entity<ExamType>(entity =>
        {
            entity.HasKey(e => e.ExamTypeId).HasName("PK__ExamType__087D50F00A3D757B");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<FeePayment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__FeePayme__9B556A383E1350A4");

            entity.HasOne(d => d.Fee).WithMany(p => p.FeePayments).HasConstraintName("FK__FeePaymen__FeeId__6754599E");

            entity.HasOne(d => d.Student).WithMany(p => p.FeePayments).HasConstraintName("FK__FeePaymen__Stude__66603565");
        });

        modelBuilder.Entity<FeeStructure>(entity =>
        {
            entity.HasKey(e => e.FeeId).HasName("PK__FeeStruc__B387B229020CC1B6");

            entity.HasOne(d => d.Class).WithMany(p => p.FeeStructures).HasConstraintName("FK__FeeStruct__Class__6383C8BA");
        });

        modelBuilder.Entity<Hostel>(entity =>
        {
            entity.HasKey(e => e.HostelId).HasName("PK__Hostels__677EEB28AB6487A5");
        });

        modelBuilder.Entity<HostelAllocation>(entity =>
        {
            entity.HasKey(e => e.AllocationId).HasName("PK__HostelAl__B3C6D64B28CBE5F5");

            entity.HasOne(d => d.Room).WithMany(p => p.HostelAllocations).HasConstraintName("FK__HostelAll__RoomI__1AD3FDA4");

            entity.HasOne(d => d.Student).WithMany(p => p.HostelAllocations).HasConstraintName("FK__HostelAll__Stude__19DFD96B");
        });

        modelBuilder.Entity<HostelRoom>(entity =>
        {
            entity.HasKey(e => e.RoomId).HasName("PK__HostelRo__328639391C30627A");

            entity.HasOne(d => d.Hostel).WithMany(p => p.HostelRooms).HasConstraintName("FK__HostelRoo__Hoste__17036CC0");
        });

        modelBuilder.Entity<Notice>(entity =>
        {
            entity.HasKey(e => e.NoticeId).HasName("PK__Notices__CE83CBE5A44417B6");

            entity.HasOne(d => d.TargetRole).WithMany(p => p.Notices).HasConstraintName("FK__Notices__TargetR__06CD04F7");
        });

        modelBuilder.Entity<Parent>(entity =>
        {
            entity.HasKey(e => e.ParentId).HasName("PK__Parents__D339516FD35126D2");

            entity.HasOne(d => d.User).WithMany(p => p.Parents).HasConstraintName("FK__Parents__UserId__4222D4EF");
        });

        modelBuilder.Entity<ParentStudent>(entity =>
        {
            entity.HasKey(e => e.ParentStudentId).HasName("PK__ParentSt__6B892BA4719390B2");

            entity.HasOne(d => d.Parent).WithMany(p => p.ParentStudents).HasConstraintName("FK__ParentStu__Paren__44FF419A");

            entity.HasOne(d => d.Student).WithMany(p => p.ParentStudents).HasConstraintName("FK__ParentStu__Stude__45F365D3");
        });

        modelBuilder.Entity<Payroll>(entity =>
        {
            entity.HasKey(e => e.PayrollId).HasName("PK__Payroll__99DFC672E8C16BD7");

            entity.HasOne(d => d.Staff).WithMany(p => p.Payrolls).HasConstraintName("FK__Payroll__StaffId__208CD6FA");
        });

        modelBuilder.Entity<Period>(entity =>
        {
            entity.HasKey(e => e.PeriodId).HasName("PK__Periods__E521BB169630DB44");
        });

        modelBuilder.Entity<Ptm>(entity =>
        {
            entity.HasKey(e => e.Ptmid).HasName("PK__PTM__74F26DD8D51FCF74");

            entity.HasOne(d => d.Class).WithMany(p => p.Ptms).HasConstraintName("FK__PTM__ClassId__6A30C649");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Ptms).HasConstraintName("FK__PTM__TeacherId__6B24EA82");
        });

        modelBuilder.Entity<Ptmfeedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__PTMFeedb__6A4BEDD6B7FA58A2");

            entity.HasOne(d => d.Parent).WithMany(p => p.Ptmfeedbacks).HasConstraintName("FK__PTMFeedba__Paren__6EF57B66");

            entity.HasOne(d => d.Ptm).WithMany(p => p.Ptmfeedbacks).HasConstraintName("FK__PTMFeedba__PTMId__6E01572D");

            entity.HasOne(d => d.Student).WithMany(p => p.Ptmfeedbacks).HasConstraintName("FK__PTMFeedba__Stude__6FE99F9F");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE1A9332CB11");
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.HasKey(e => e.SectionId).HasName("PK__Sections__80EF087235A48325");

            entity.HasOne(d => d.Class).WithMany(p => p.Sections).HasConstraintName("FK__Sections__ClassI__4AB81AF0");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__Staff__96D4AB17F3290D20");

            entity.HasOne(d => d.User).WithMany(p => p.Staff).HasConstraintName("FK__Staff__UserId__1DB06A4F");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Students__32C52B99E05E840F");

            entity.HasOne(d => d.User).WithMany(p => p.Students).HasConstraintName("FK__Students__UserId__3F466844");
        });

        modelBuilder.Entity<StudentComplaint>(entity =>
        {
            entity.HasKey(e => e.ComplaintId).HasName("PK__StudentC__740D898F63A59E5A");

            entity.Property(e => e.ComplaintDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Status).HasDefaultValue("Pending");

            entity.HasOne(d => d.ComplaintCategory).WithMany(p => p.StudentComplaints).HasConstraintName("FK_StudentComplaints_ComplaintCategories");

            entity.HasOne(d => d.ResolvedByNavigation).WithMany(p => p.StudentComplaints).HasConstraintName("FK__StudentCo__Resol__2B0A656D");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentComplaints).HasConstraintName("FK__StudentCo__Stude__2739D489");

            entity.HasOne(d => d.Teacher).WithMany(p => p.StudentComplaints).HasConstraintName("FK__StudentCo__Teach__282DF8C2");
        });

        modelBuilder.Entity<StudentTransport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StudentT__3214EC07084C47C2");

            entity.HasOne(d => d.Bus).WithMany(p => p.StudentTransports).HasConstraintName("FK__StudentTr__BusId__0C85DE4D");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentTransports).HasConstraintName("FK__StudentTr__Stude__0B91BA14");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("PK__Subjects__AC1BA3A8E79D4A86");

            entity.HasOne(d => d.Class).WithMany(p => p.Subjects).HasConstraintName("FK__Subjects__ClassI__4D94879B");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId).HasName("PK__Teachers__EDF259641B008A31");

            entity.HasOne(d => d.Subject).WithMany(p => p.Teachers).HasConstraintName("FK__Teachers__Subjec__5165187F");

            entity.HasOne(d => d.User).WithMany(p => p.Teachers).HasConstraintName("FK__Teachers__UserId__5070F446");
        });

        modelBuilder.Entity<TeacherAttendance>(entity =>
        {
            entity.HasKey(e => e.AttendanceId).HasName("PK__TeacherA__8B69261CC672BC6A");

            entity.HasOne(d => d.Teacher).WithMany(p => p.TeacherAttendances).HasConstraintName("FK__TeacherAt__Teach__5812160E");
        });

        modelBuilder.Entity<Timetable>(entity =>
        {
            entity.HasKey(e => e.TimetableId).HasName("PK__Timetabl__68413F60EB06E7B1");

            entity.HasOne(d => d.Class).WithMany(p => p.Timetables).HasConstraintName("FK__Timetable__Class__74AE54BC");

            entity.HasOne(d => d.Period).WithMany(p => p.Timetables).HasConstraintName("FK__Timetable__Perio__787EE5A0");

            entity.HasOne(d => d.Section).WithMany(p => p.Timetables).HasConstraintName("FK__Timetable__Secti__75A278F5");

            entity.HasOne(d => d.Subject).WithMany(p => p.Timetables).HasConstraintName("FK__Timetable__Subje__76969D2E");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Timetables).HasConstraintName("FK__Timetable__Teach__778AC167");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C19A04FD7");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Role).WithMany(p => p.Users).HasConstraintName("FK__Users__RoleId__3A81B327");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
