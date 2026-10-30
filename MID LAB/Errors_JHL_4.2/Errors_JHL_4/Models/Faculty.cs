using Errors_JHL_4.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Errors_JHL_4.Models
{
    public class Faculty
    {

        [Required(ErrorMessage = "Required")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "5 to 50")]
        public string Name { get; set; }

        [Range(10, 30, ErrorMessage = "10 to 30")]
        public int Age { get; set; }

        [DateCheck]
        [Display(Name = "Date of Birth :")]
        [DeptCheck("fct")]
        public DateTime Dob { get; set; }


        [Required]
        public string Dept { get; set; }
    }
}
