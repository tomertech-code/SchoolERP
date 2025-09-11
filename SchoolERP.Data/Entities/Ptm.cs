using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Entities;

[Table("PTM")]
public partial class Ptm
{
    [Key]
    [Column("PTMId")]
    public int Ptmid { get; set; }

    public int? ClassId { get; set; }

    public int? TeacherId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? MeetingDate { get; set; }

    [StringLength(255)]
    public string? Agenda { get; set; }

    [ForeignKey("ClassId")]
    [InverseProperty("Ptms")]
    public virtual Class? Class { get; set; }

    [InverseProperty("Ptm")]
    public virtual ICollection<Ptmfeedback> Ptmfeedbacks { get; set; } = new List<Ptmfeedback>();

    [ForeignKey("TeacherId")]
    [InverseProperty("Ptms")]
    public virtual Teacher? Teacher { get; set; }
}
