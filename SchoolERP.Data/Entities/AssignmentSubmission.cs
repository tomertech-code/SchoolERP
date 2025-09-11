using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Entities;

public partial class AssignmentSubmission
{
    [Key]
    public int SubmissionId { get; set; }

    public int? AssignmentId { get; set; }

    public int? StudentId { get; set; }

    public DateOnly? SubmittedDate { get; set; }

    [StringLength(255)]
    public string? FilePath { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal? Marks { get; set; }

    [StringLength(255)]
    public string? Remark { get; set; }

    [ForeignKey("AssignmentId")]
    [InverseProperty("AssignmentSubmissions")]
    public virtual Assignment? Assignment { get; set; }

    [ForeignKey("StudentId")]
    [InverseProperty("AssignmentSubmissions")]
    public virtual Student? Student { get; set; }
}
