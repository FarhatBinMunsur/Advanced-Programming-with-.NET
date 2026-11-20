using System.ComponentModel.DataAnnotations;

namespace EFCoreCF.Models
{
    public class Depertment
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        public string Deptname { get; set; }
    }
}
