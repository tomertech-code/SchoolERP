using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Entities;

public partial class Assignment
{
    [Key]
    public int AssignmentId { get; set; }

    public int? ClassId { get; set; }

    public int? SectionId { get; set; }

    public int? SubjectId { get; set; }

    public int? TeacherId { get; set; }

    [StringLength(255)]
    public string? Title { get; set; }

    public string? Description { get; set; }

    public DateOnly? AssignedDate { get; set; }

    public DateOnly? DueDate { get; set; }

    [InverseProperty("Assignment")]
    public virtual ICollection<AssignmentSubmission> AssignmentSubmissions { get; set; } = new List<AssignmentSubmission>();

    [ForeignKey("ClassId")]
    [InverseProperty("Assignments")]
    public virtual Class? Class { get; set; }

    [ForeignKey("SectionId")]
    [InverseProperty("Assignments")]
    public virtual Section? Section { get; set; }

    [ForeignKey("SubjectId")]
    [InverseProperty("Assignments")]
    public virtual Subject? Subject { get; set; }

    [ForeignKey("TeacherId")]
    [InverseProperty("Assignments")]
    public virtual Teacher? Teacher { get; set; }
}
