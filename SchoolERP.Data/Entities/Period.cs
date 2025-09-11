using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Entities;

public partial class Period
{
    [Key]
    public int PeriodId { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    [StringLength(50)]
    public string? PeriodName { get; set; }

    [InverseProperty("Period")]
    public virtual ICollection<Timetable> Timetables { get; set; } = new List<Timetable>();
}
