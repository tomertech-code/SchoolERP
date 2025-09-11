using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Entities;

public partial class HostelAllocation
{
    [Key]
    public int AllocationId { get; set; }

    public int? StudentId { get; set; }

    public int? RoomId { get; set; }

    public DateOnly? AllocationDate { get; set; }

    [ForeignKey("RoomId")]
    [InverseProperty("HostelAllocations")]
    public virtual HostelRoom? Room { get; set; }

    [ForeignKey("StudentId")]
    [InverseProperty("HostelAllocations")]
    public virtual Student? Student { get; set; }
}
