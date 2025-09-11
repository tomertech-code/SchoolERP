using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Entities;

public partial class Staff
{
    [Key]
    public int StaffId { get; set; }

    public int? UserId { get; set; }

    [StringLength(100)]
    public string? StaffName { get; set; }

    [StringLength(50)]
    public string? Role { get; set; }

    [StringLength(20)]
    public string? Phone { get; set; }

    public DateOnly? HireDate { get; set; }

    [InverseProperty("Staff")]
    public virtual ICollection<Payroll> Payrolls { get; set; } = new List<Payroll>();

    [ForeignKey("UserId")]
    [InverseProperty("Staff")]
    public virtual User? User { get; set; }
}
