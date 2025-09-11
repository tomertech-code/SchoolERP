using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Entities;

public partial class HostelRoom
{
    [Key]
    public int RoomId { get; set; }

    public int? HostelId { get; set; }

    [StringLength(20)]
    public string? RoomNumber { get; set; }

    public int? Capacity { get; set; }

    [ForeignKey("HostelId")]
    [InverseProperty("HostelRooms")]
    public virtual Hostel? Hostel { get; set; }

    [InverseProperty("Room")]
    public virtual ICollection<HostelAllocation> HostelAllocations { get; set; } = new List<HostelAllocation>();
}
