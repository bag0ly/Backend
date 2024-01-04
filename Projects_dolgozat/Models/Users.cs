using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projects_dolgozat.Models
{
    public class Users
    {
        [Key]
        public Guid UserID { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string? UserName { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
      
        public string? Email { get; set; }
    }
}
