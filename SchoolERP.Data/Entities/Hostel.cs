using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Entities;

public partial class Hostel
{
    [Key]
    public int HostelId { get; set; }

    [StringLength(100)]
    public string? HostelName { get; set; }

    [StringLength(255)]
    public string? Location { get; set; }

    [StringLength(100)]
    public string? WardenName { get; set; }

    [InverseProperty("Hostel")]
    public virtual ICollection<HostelRoom> HostelRooms { get; set; } = new List<HostelRoom>();
}
