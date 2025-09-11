using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Entities;

public partial class FeePayment
{
    [Key]
    public int PaymentId { get; set; }

    public int? StudentId { get; set; }

    public int? FeeId { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? PaidAmount { get; set; }

    public DateOnly? PaymentDate { get; set; }

    [StringLength(50)]
    public string? Mode { get; set; }

    [ForeignKey("FeeId")]
    [InverseProperty("FeePayments")]
    public virtual FeeStructure? Fee { get; set; }

    [ForeignKey("StudentId")]
    [InverseProperty("FeePayments")]
    public virtual Student? Student { get; set; }
}
