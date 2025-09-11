using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Entities;

public partial class Class
{
    [Key]
    public int ClassId { get; set; }

    [StringLength(50)]
    public string ClassName { get; set; } = null!;

    [InverseProperty("Class")]
    public virtual ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();

    [InverseProperty("Class")]
    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();

    [InverseProperty("Class")]
    public virtual ICollection<FeeStructure> FeeStructures { get; set; } = new List<FeeStructure>();

    [InverseProperty("Class")]
    public virtual ICollection<Ptm> Ptms { get; set; } = new List<Ptm>();

    [InverseProperty("Class")]
    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();

    [InverseProperty("Class")]
    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();

    [InverseProperty("Class")]
    public virtual ICollection<Timetable> Timetables { get; set; } = new List<Timetable>();
}
