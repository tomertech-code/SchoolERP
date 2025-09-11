using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Entities;

[Table("TeacherAttendance")]
public partial class TeacherAttendance
{
    [Key]
    public int AttendanceId { get; set; }

    public int? TeacherId { get; set; }

    public DateOnly? Date { get; set; }

    [StringLength(20)]
    public string? Status { get; set; }

    [StringLength(255)]
    public string? Remark { get; set; }

    [ForeignKey("TeacherId")]
    [InverseProperty("TeacherAttendances")]
    public virtual Teacher? Teacher { get; set; }
}
