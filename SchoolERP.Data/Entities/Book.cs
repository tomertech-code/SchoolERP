using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Entities;

public partial class Book
{
    [Key]
    public int BookId { get; set; }

    [Column("ISBN")]
    [StringLength(50)]
    public string? Isbn { get; set; }

    [StringLength(255)]
    public string? Title { get; set; }

    [StringLength(100)]
    public string? Author { get; set; }

    [StringLength(100)]
    public string? Publisher { get; set; }

    public int? Quantity { get; set; }

    [InverseProperty("Book")]
    public virtual ICollection<BookIssue> BookIssues { get; set; } = new List<BookIssue>();
}
