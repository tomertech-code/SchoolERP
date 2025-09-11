using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Entities;

[Table("ParentStudent")]
public partial class ParentStudent
{
    [Key]
    public int ParentStudentId { get; set; }

    public int? ParentId { get; set; }

    public int? StudentId { get; set; }

    [ForeignKey("ParentId")]
    [InverseProperty("ParentStudents")]
    public virtual Parent? Parent { get; set; }

    [ForeignKey("StudentId")]
    [InverseProperty("ParentStudents")]
    public virtual Student? Student { get; set; }
}
