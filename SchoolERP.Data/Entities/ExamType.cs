using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Entities;

public partial class ExamType
{
    [Key]
    public int ExamTypeId { get; set; }

    [StringLength(100)]
    public string ExamName { get; set; } = null!;

    [StringLength(250)]
    public string? Description { get; set; }

    public bool IsActive { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [InverseProperty("ExamType")]
    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();
}
