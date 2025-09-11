using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Entities;

public partial class ExamResult
{
    [Key]
    public int ResultId { get; set; }

    public int? ExamId { get; set; }

    public int? StudentId { get; set; }

    public int? SubjectId { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal? MarksObtained { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal? MaxMarks { get; set; }

    [ForeignKey("ExamId")]
    [InverseProperty("ExamResults")]
    public virtual Exam? Exam { get; set; }

    [ForeignKey("StudentId")]
    [InverseProperty("ExamResults")]
    public virtual Student? Student { get; set; }

    [ForeignKey("SubjectId")]
    [InverseProperty("ExamResults")]
    public virtual Subject? Subject { get; set; }
}
