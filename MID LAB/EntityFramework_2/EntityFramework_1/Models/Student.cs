using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework_1.Models

{

    public class NameError : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null) {
                if (value.ToString().Length < 3)
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
            return ValidationResult.Success;
        }
    }

    public class CgpaError : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value!=null)
            {
                double cgpa = (double)value;
                if (cgpa<0 || cgpa>4.0)
                {
                    return new ValidationResult("Invalid CGPA");
                }
            }
            return ValidationResult.Success;
        }
    }


    [Table("students")]
    public class Student
    {
        public int id { get; set; }

        [Required(ErrorMessage ="Name is Required")]
        [NameError(ErrorMessage ="Invalid Name Error")]
        public string name { get; set; }

        [Required(ErrorMessage ="Email is required")]
        [EmailAddress]
        //[EmailAddress(ErrorMessage ="Email Format is not correct")]
        public string email { get; set; }

        [Required(ErrorMessage = "CGPA is required")]
        [Range(0, 4)]
        [CgpaError]
        public double? cgpa { get; set; }




    }
}
