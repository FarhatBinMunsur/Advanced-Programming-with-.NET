using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFcoreDFpmb.Models;

public partial class Depertment
{
    public int Id { get; set; }

    [RegularExpression("^[A-Z]+$")]
    public string DeptName { get; set; } = null!;

    [Range(30,60)]
    public int Courses { get; set; }
}
