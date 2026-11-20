using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Models;

public partial class BookLoan
{
    [Key]
    public int LoanId { get; set; }

    [Required]
    [StringLength(50,MinimumLength =3)]
    public string MemberName { get; set; } = null!;

    [Required]
    public string Genre { get; set; } = null!;

    [Range(1,15)]
    public int LoanDays { get; set; }

    [Range(10,500)]
    public decimal LateFee { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime BorrowedAt { get; set; }
}
