using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework_1.Models

{
    [Table("students")]
    public class Student
    {
        public int id { get; set; }

        [Required(ErrorMessage ="Name is Required")]
        public string name { get; set; }

        [Required(ErrorMessage ="Email is required")]
        public string email { get; set; }

        public double? cgpa { get; set; }




    }
}
