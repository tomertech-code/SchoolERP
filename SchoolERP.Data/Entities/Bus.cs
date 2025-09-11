using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Entities;

public partial class Bus
{
    [Key]
    public int BusId { get; set; }

    [StringLength(20)]
    public string BusNumber { get; set; } = null!;

    [StringLength(100)]
    public string? DriverName { get; set; }

    [StringLength(20)]
    public string? DriverPhone { get; set; }

    [StringLength(255)]
    public string? Route { get; set; }

    [InverseProperty("Bus")]
    public virtual ICollection<StudentTransport> StudentTransports { get; set; } = new List<StudentTransport>();
}
