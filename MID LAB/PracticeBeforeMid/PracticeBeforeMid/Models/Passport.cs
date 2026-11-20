using Microsoft.AspNetCore.Hosting.Server;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace PracticeBeforeMid.Models
{

    public class CustomRequired : ValidationAttribute
    {
        public string isint;
        public bool target;

        public CustomRequired(string isint, bool target)
        {
            this.isint = isint;
            this.target = target;

        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var property = validationContext.ObjectType.GetProperty(isint);

            if (property == null) {
                return new ValidationResult(ErrorMessage="Invaalid propert");
            }

            var propValue = property.GetValue(validationContext.ObjectInstance);
            
            if(propValue!=null && propValue.Equals(target) && value==null)
            {
                return new ValidationResult(ErrorMessage ?? "Give your passport No");
            }
            
            return ValidationResult.Success;   
        }
    }

    public class Passport
    {
        public bool IsInternational {  get; set; }

        [Display(Name ="Passport Number")]
        [CustomRequired("IsInternational",true)]
        public string PassportNo {  get; set; }

        [Required]
        public string Dept {  get; set; }

    }
}
