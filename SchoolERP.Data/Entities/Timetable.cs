using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Entities;

[Table("Timetable")]
public partial class Timetable
{
    [Key]
    public int TimetableId { get; set; }

    public int? ClassId { get; set; }

    public int? SectionId { get; set; }

    public int? SubjectId { get; set; }

    public int? TeacherId { get; set; }

    public int? PeriodId { get; set; }

    [StringLength(20)]
    public string? DayOfWeek { get; set; }

    [ForeignKey("ClassId")]
    [InverseProperty("Timetables")]
    public virtual Class? Class { get; set; }

    [ForeignKey("PeriodId")]
    [InverseProperty("Timetables")]
    public virtual Period? Period { get; set; }

    [ForeignKey("SectionId")]
    [InverseProperty("Timetables")]
    public virtual Section? Section { get; set; }

    [ForeignKey("SubjectId")]
    [InverseProperty("Timetables")]
    public virtual Subject? Subject { get; set; }

    [ForeignKey("TeacherId")]
    [InverseProperty("Timetables")]
    public virtual Teacher? Teacher { get; set; }
}
