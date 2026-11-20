using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFCoreDFPractice.Models;

public partial class Employee
{
    [Key]
    public int EmpId { get; set; }

    [Required]
    [StringLength(50)]
    public string EmpName { get; set; } = null!;

    [Required]
    public string Depertment { get; set; } = null!;

    [Range(10000,300000)]
    public double Salary { get; set; }

    [Range(0,20)]
    public int ExperienceYears { get; set; }

    [DataType("dd-mm-yyyy")]
    public DateTime JoinedAt { get; set; }
}
