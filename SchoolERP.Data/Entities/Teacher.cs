using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Entities;

public partial class Teacher
{
    [Key]
    public int TeacherId { get; set; }

    public int? UserId { get; set; }

    [StringLength(50)]
    public string? FirstName { get; set; }

    [StringLength(50)]
    public string? LastName { get; set; }

    public int? SubjectId { get; set; }

    [StringLength(20)]
    public string? Phone { get; set; }

    public DateOnly? HireDate { get; set; }

    [InverseProperty("Teacher")]
    public virtual ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();

    [InverseProperty("Teacher")]
    public virtual ICollection<Ptm> Ptms { get; set; } = new List<Ptm>();

    [InverseProperty("Teacher")]
    public virtual ICollection<StudentComplaint> StudentComplaints { get; set; } = new List<StudentComplaint>();

    [ForeignKey("SubjectId")]
    [InverseProperty("Teachers")]
    public virtual Subject? Subject { get; set; }

    [InverseProperty("Teacher")]
    public virtual ICollection<TeacherAttendance> TeacherAttendances { get; set; } = new List<TeacherAttendance>();

    [InverseProperty("Teacher")]
    public virtual ICollection<Timetable> Timetables { get; set; } = new List<Timetable>();

    [ForeignKey("UserId")]
    [InverseProperty("Teachers")]
    public virtual User? User { get; set; }
}
