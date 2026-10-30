using System.ComponentModel.DataAnnotations;

namespace LabTask.Models
{
    public class CrscdCheck : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string val = value.ToString();
                for (int i = 0; i < val.Length; i++) {

                    if (i < 2)
                    {
                        if (!(val[i] >= 'A' && val[i] <= 'Z'))
                        {
                            return new ValidationResult(ErrorMessage = "Enter right Course Code");
                        }
                    }


                    else 
                    {
                        if (!(val[i] >= '0' && val[i] <= '9'))
                        {
                            return new ValidationResult(ErrorMessage = "Enter right Course Code");
                        }
                    }

                }
            }

            return ValidationResult.Success;
        }
    }

    public class Student
    {
        [Required]
        [StringLength(60)]
        public string Fullname {  get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(10)]
        [CrscdCheck(ErrorMessage ="Wrong Course Code")]
        public string CourseCode {  get; set; }

        [Required]
        [Range(1,4)]
        public int creditHr { get; set; }

        [Required]
        [Range(5000,100000)]
        public int Semfee {  get; set; }
    }
}
