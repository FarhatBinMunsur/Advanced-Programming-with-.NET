using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CompanyMS.Models;

public partial class Employee
{
    [Key]
    public int EmpId { get; set; }

    public string Empname { get; set; } = null!;

    public string Department { get; set; } = null!;

    public decimal Salary { get; set; }

    public int ExperienceYears { get; set; }

    public DateTime JoinedAt { get; set; }
}
