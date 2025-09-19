using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Entities;

public partial class BookIssue
{
    [Key]
    public int IssueId { get; set; }

    public int? BookId { get; set; }

    public int? StudentId { get; set; }
    public bool IsReturn { get; set; }

    public DateOnly? IssueDate { get; set; }

    public DateOnly? DueDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    [ForeignKey("BookId")]
    [InverseProperty("BookIssues")]
    public virtual Book? Book { get; set; }

    [ForeignKey("StudentId")]
    [InverseProperty("BookIssues")]
    public virtual Student? Student { get; set; }
}
