using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Entities;

public partial class ComplaintCategory
{
    [Key]
    public int ComplaintCategoryId { get; set; }

    [StringLength(100)]
    public string CategoryName { get; set; } = null!;

    [StringLength(250)]
    public string? Description { get; set; }

    public bool IsActive { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [InverseProperty("ComplaintCategory")]
    public virtual ICollection<StudentComplaint> StudentComplaints { get; set; } = new List<StudentComplaint>();
}
