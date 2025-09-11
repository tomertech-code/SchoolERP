using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Entities;

public partial class Notice
{
    [Key]
    public int NoticeId { get; set; }

    [StringLength(255)]
    public string? Title { get; set; }

    public string? Message { get; set; }

    public DateOnly? NoticeDate { get; set; }

    public int? TargetRoleId { get; set; }

    [ForeignKey("TargetRoleId")]
    [InverseProperty("Notices")]
    public virtual Role? TargetRole { get; set; }
}
