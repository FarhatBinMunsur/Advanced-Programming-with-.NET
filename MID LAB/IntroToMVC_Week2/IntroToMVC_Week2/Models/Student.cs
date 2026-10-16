using System.ComponentModel.DataAnnotations;

namespace IntroToMVC_Week2.Models
{
    public class Student
    {
        [Required(ErrorMessage ="Name is Required")]
        public string Name { get; set; }

        [Range(10,100,ErrorMessage ="10 to 100")]
        public int Age { get; set; }
    }
}
