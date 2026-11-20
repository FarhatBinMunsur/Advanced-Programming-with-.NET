using System;
using System.Collections.Generic;

namespace EFcoreDFpmb.Models;

public partial class Student
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public double? Cgpa { get; set; }

    public string? Password { get; set; }
}
