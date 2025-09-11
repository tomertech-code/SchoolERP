using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Entities;

public partial class StudentComplaint
{
    [Key]
    public int ComplaintId { get; set; }

    public int? StudentId { get; set; }

    public int? TeacherId { get; set; }

    [StringLength(255)]
    public string ComplaintTitle { get; set; } = null!;

    public string ComplaintText { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? ComplaintDate { get; set; }

    [StringLength(50)]
    public string? Status { get; set; }

    public string? ResolutionText { get; set; }

    public int? ResolvedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ResolvedDate { get; set; }

    public int? ComplaintCategoryId { get; set; }

    [ForeignKey("ComplaintCategoryId")]
    [InverseProperty("StudentComplaints")]
    public virtual ComplaintCategory? ComplaintCategory { get; set; }

    [ForeignKey("ResolvedBy")]
    [InverseProperty("StudentComplaints")]
    public virtual User? ResolvedByNavigation { get; set; }

    [ForeignKey("StudentId")]
    [InverseProperty("StudentComplaints")]
    public virtual Student? Student { get; set; }

    [ForeignKey("TeacherId")]
    [InverseProperty("StudentComplaints")]
    public virtual Teacher? Teacher { get; set; }
}
