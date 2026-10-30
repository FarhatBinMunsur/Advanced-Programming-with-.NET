using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using Errors_JHL_4.Attributes;

namespace Errors_JHL_4.Models
{
    public class DateCheck : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)

            {
                DateTime date = Convert.ToDateTime(value);
                if (date> DateTime.Now)
                {
                    return new ValidationResult(ErrorMessage="Invalid Date");
                }
            }
            return ValidationResult.Success;
        }
    }

 
    public class Student
    {
        [Required(ErrorMessage ="Required")]
        [StringLength(50,MinimumLength =5, ErrorMessage ="5 to 50")]
        public string Name {  get; set; }

        [Range(10,30,ErrorMessage ="10 to 30")]
        public int Age { get; set; }

        [DateCheck]
        [Display(Name="Date of Birth :")]
        [DeptCheck("st")]
        public DateTime Dob { get; set; }


        [Required]
        public string Dept {  get; set; }
    }
}
