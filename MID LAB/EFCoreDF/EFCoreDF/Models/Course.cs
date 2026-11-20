namespace EFCoreDF.Models;

public partial class Course
{
    public int Id { get; set; }


    public string CourseName { get; set; } = null!;

    public int Credit { get; set; }
}
