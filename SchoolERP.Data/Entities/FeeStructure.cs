using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Entities;

public partial class FeeStructure
{
    [Key]
    public int FeeId { get; set; }

    public int? ClassId { get; set; }

    [StringLength(100)]
    public string? FeeType { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Amount { get; set; }

    [ForeignKey("ClassId")]
    [InverseProperty("FeeStructures")]
    public virtual Class? Class { get; set; }

    [InverseProperty("Fee")]
    public virtual ICollection<FeePayment> FeePayments { get; set; } = new List<FeePayment>();
}
