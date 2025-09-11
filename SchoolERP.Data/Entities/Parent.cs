using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Entities;

public partial class Parent
{
    [Key]
    public int ParentId { get; set; }

    public int? UserId { get; set; }

    [StringLength(100)]
    public string? FatherName { get; set; }

    [StringLength(100)]
    public string? MotherName { get; set; }

    [StringLength(20)]
    public string? Phone { get; set; }

    [StringLength(255)]
    public string? Address { get; set; }

    [InverseProperty("Parent")]
    public virtual ICollection<ParentStudent> ParentStudents { get; set; } = new List<ParentStudent>();

    [InverseProperty("Parent")]
    public virtual ICollection<Ptmfeedback> Ptmfeedbacks { get; set; } = new List<Ptmfeedback>();

    [ForeignKey("UserId")]
    [InverseProperty("Parents")]
    public virtual User? User { get; set; }
}
