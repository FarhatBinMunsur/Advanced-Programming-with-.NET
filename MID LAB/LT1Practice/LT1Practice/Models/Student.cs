using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace LT1Practice.Models
{
    public class DeptCheck : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            if (value != null) { 
                if(value.ToString()=="CSE" ||  value.ToString()=="EEE" || value.ToString() == "BBA")
                {

                }

                else
                {
                    return new ValidationResult(ErrorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
    public class Student
    {
        public int Id {  get; set; }

        [Required]
        public string Name {  get; set; }

        [Required(ErrorMessage ="Enter the cgpa")]
        
        public float Cgpa { get; set; }

        [DeptCheck(ErrorMessage ="Enter right Dept")]
        public string Dept {  get; set; }

    }
}
