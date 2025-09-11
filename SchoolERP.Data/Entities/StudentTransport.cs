using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Entities;

[Table("StudentTransport")]
public partial class StudentTransport
{
    [Key]
    public int Id { get; set; }

    public int? StudentId { get; set; }

    public int? BusId { get; set; }

    [StringLength(255)]
    public string? PickupPoint { get; set; }

    [StringLength(255)]
    public string? DropPoint { get; set; }

    [ForeignKey("BusId")]
    [InverseProperty("StudentTransports")]
    public virtual Bus? Bus { get; set; }

    [ForeignKey("StudentId")]
    [InverseProperty("StudentTransports")]
    public virtual Student? Student { get; set; }
}
