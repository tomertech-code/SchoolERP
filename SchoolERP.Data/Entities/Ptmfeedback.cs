using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Entities;

[Table("PTMFeedback")]
public partial class Ptmfeedback
{
    [Key]
    public int FeedbackId { get; set; }

    [Column("PTMId")]
    public int? Ptmid { get; set; }

    public int? ParentId { get; set; }

    public int? StudentId { get; set; }

    [StringLength(500)]
    public string? FeedbackText { get; set; }

    [ForeignKey("ParentId")]
    [InverseProperty("Ptmfeedbacks")]
    public virtual Parent? Parent { get; set; }

    [ForeignKey("Ptmid")]
    [InverseProperty("Ptmfeedbacks")]
    public virtual Ptm? Ptm { get; set; }

    [ForeignKey("StudentId")]
    [InverseProperty("Ptmfeedbacks")]
    public virtual Student? Student { get; set; }
}
