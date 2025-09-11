using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Entities;

[Table("Attendance")]
public partial class Attendance
{
    [Key]
    public int AttendanceId { get; set; }

    public int? StudentId { get; set; }

    public DateOnly? Date { get; set; }

    [StringLength(20)]
    public string? Status { get; set; }

    [StringLength(255)]
    public string? Remark { get; set; }

    [ForeignKey("StudentId")]
    [InverseProperty("Attendances")]
    public virtual Student? Student { get; set; }
}
