using Errors_JHL_4.Models;
using System.ComponentModel.DataAnnotations;


namespace Errors_JHL_4.Attributes
{
    public class DeptCheck : ValidationAttribute
    {
        protected string user;

        //check elligibility based on userType and Age
        public DeptCheck(string user)
        {
            this.user = user;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            object modelData;
            

            if (value is DateTime dt)
            {
                var age = (DateTime.Now - dt).TotalDays / 365;      // (datetime-datetime) gives timespan format.convert the timsapn to days,minutes,hours

                

                if (validationContext.ObjectInstance is Student st)
                {
                    modelData = (Student)validationContext.ObjectInstance;

                }

                if (user == "fct")
                {
                    modelData = (Faculty)validationContext.ObjectInstance;
                }

                //cast to model. So that I can access the properties of the model.

                if (age < 18 && user== "st")
                {
                    return new ValidationResult("Student Age must be grater than 18 to Apply");
                }

                if (age < 24 && user== "fct" )
                {
                    return new ValidationResult("Faculty Age must be grater than 24 to Apply");
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
