using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Entities;

public partial class Subject
{
    [Key]
    public int SubjectId { get; set; }

    [StringLength(100)]
    public string SubjectName { get; set; } = null!;

    public int? ClassId { get; set; }

    [InverseProperty("Subject")]
    public virtual ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();

    [ForeignKey("ClassId")]
    [InverseProperty("Subjects")]
    public virtual Class? Class { get; set; }

    [InverseProperty("Subject")]
    public virtual ICollection<ExamResult> ExamResults { get; set; } = new List<ExamResult>();

    [InverseProperty("Subject")]
    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();

    [InverseProperty("Subject")]
    public virtual ICollection<Timetable> Timetables { get; set; } = new List<Timetable>();
}
