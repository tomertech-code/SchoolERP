using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Entities;

[Index("AdmissionNo", Name = "UQ__Students__C97E2711741708FD", IsUnique = true)]
public partial class Student
{
    [Key]
    public int StudentId { get; set; }

    public int? UserId { get; set; }

    [StringLength(50)]
    public string AdmissionNo { get; set; } = null!;

    [StringLength(50)]
    public string? FirstName { get; set; }

    [StringLength(50)]
    public string? LastName { get; set; }

    [Column("DOB")]
    public DateOnly? Dob { get; set; }

    [StringLength(10)]
    public string? Gender { get; set; }

    public int? ClassId { get; set; }

    public int? SectionId { get; set; }

    [StringLength(255)]
    public string? Address { get; set; }

    public DateOnly? EnrollmentDate { get; set; }

    [InverseProperty("Student")]
    public virtual ICollection<AssignmentSubmission> AssignmentSubmissions { get; set; } = new List<AssignmentSubmission>();

    [InverseProperty("Student")]
    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    [InverseProperty("Student")]
    public virtual ICollection<BookIssue> BookIssues { get; set; } = new List<BookIssue>();

    [InverseProperty("Student")]
    public virtual ICollection<ExamResult> ExamResults { get; set; } = new List<ExamResult>();

    [InverseProperty("Student")]
    public virtual ICollection<FeePayment> FeePayments { get; set; } = new List<FeePayment>();

    [InverseProperty("Student")]
    public virtual ICollection<HostelAllocation> HostelAllocations { get; set; } = new List<HostelAllocation>();

    [InverseProperty("Student")]
    public virtual ICollection<ParentStudent> ParentStudents { get; set; } = new List<ParentStudent>();

    [InverseProperty("Student")]
    public virtual ICollection<Ptmfeedback> Ptmfeedbacks { get; set; } = new List<Ptmfeedback>();

    [InverseProperty("Student")]
    public virtual ICollection<StudentComplaint> StudentComplaints { get; set; } = new List<StudentComplaint>();

    [InverseProperty("Student")]
    public virtual ICollection<StudentTransport> StudentTransports { get; set; } = new List<StudentTransport>();

    [ForeignKey("UserId")]
    [InverseProperty("Students")]
    public virtual User? User { get; set; }
}
