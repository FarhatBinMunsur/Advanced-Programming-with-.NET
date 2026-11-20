using Errors_JHL_4.Models;
using System.ComponentModel.DataAnnotations;


namespace Errors_JHL_4.Attributes
{
    public class DeptCheck : ValidationAttribute
    {

        //check elligibility based on userType and Age
  
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            

            if (value is DateTime dt)
            {
                var age = (DateTime.Now - dt).TotalDays / 365;      // (datetime-datetime) gives timespan format.convert the timsapn to days,minutes,hours

                var dept = validationContext.ObjectType.GetProperty("Dept");

                if(dept == null)
                {
                    return new ValidationResult("Invalid Dept");
                }

                var deptValue = dept.GetValue(validationContext.ObjectInstance)?.ToString();

                if (deptValue == null)
                {
                    return new ValidationResult("Invalid Dept");
                }
                if (deptValue!=null && deptValue =="1" && age<18)
                {  
                        return new ValidationResult("To Select CSE, Age must be grater than 18 to Apply");
                }

                if (deptValue != null && deptValue == "2" && age<24)
                {
                        return new ValidationResult("To Select EEE, Age must be grater than 24 to Apply");
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
}
