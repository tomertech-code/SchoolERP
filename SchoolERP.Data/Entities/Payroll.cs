using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Entities;

[Table("Payroll")]
public partial class Payroll
{
    [Key]
    public int PayrollId { get; set; }

    public int? StaffId { get; set; }

    [StringLength(20)]
    public string? MonthYear { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? BasicSalary { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Allowances { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Deductions { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? NetSalary { get; set; }

    public DateOnly? PaidDate { get; set; }

    [ForeignKey("StaffId")]
    [InverseProperty("Payrolls")]
    public virtual Staff? Staff { get; set; }
}
