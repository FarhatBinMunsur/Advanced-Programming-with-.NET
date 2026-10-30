using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

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

    public class DeptCheck : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            if (value is DateTime dt)
            {
                var age = (DateTime.Now - dt).TotalDays/365;      // (datetime-datetime) gives timespan format.convert the timsapn to days,minutes,hours
                var modelData = (Student)validationContext.ObjectInstance;  //cast to model. So that I can access the properties of the model.

                if (age<18 && modelData.Dept== "1")
                {
                    return new ValidationResult("Age must be grater than 18 to enroll in CSE");
                }

                if(age<21 && modelData.Dept== "2")
                {
                    return new ValidationResult("Age must be grater than 21 to enroll in EEE");
                }
            }

            //datetime na hole
            else
            {
                return new ValidationResult(ErrorMessage = "Invalid input.Not a Date.");
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
        [DeptCheck]
        public DateTime Dob { get; set; }


        [Required]
        public string Dept {  get; set; }
    }
}
