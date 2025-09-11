using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Entities;

public partial class Exam
{
    [Key]
    public int ExamId { get; set; }

    public int? ClassId { get; set; }

    [StringLength(100)]
    public string? ExamName { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public int? ExamTypeId { get; set; }

    [ForeignKey("ClassId")]
    [InverseProperty("Exams")]
    public virtual Class? Class { get; set; }

    [InverseProperty("Exam")]
    public virtual ICollection<ExamResult> ExamResults { get; set; } = new List<ExamResult>();

    [ForeignKey("ExamTypeId")]
    [InverseProperty("Exams")]
    public virtual ExamType? ExamType { get; set; }
}
