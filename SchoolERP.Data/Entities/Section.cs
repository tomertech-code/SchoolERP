using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Entities;

public partial class Section
{
    [Key]
    public int SectionId { get; set; }

    public int? ClassId { get; set; }

    [StringLength(50)]
    public string SectionName { get; set; } = null!;

    [InverseProperty("Section")]
    public virtual ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();

    [ForeignKey("ClassId")]
    [InverseProperty("Sections")]
    public virtual Class? Class { get; set; }

    [InverseProperty("Section")]
    public virtual ICollection<Timetable> Timetables { get; set; } = new List<Timetable>();
}
