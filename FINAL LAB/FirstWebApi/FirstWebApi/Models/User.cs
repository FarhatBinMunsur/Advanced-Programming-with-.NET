using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstWebApi.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(50)]
        public string? Name { get; set; }

        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Password {  get; set; }


        public string? role {  get; set; }

    }
}
