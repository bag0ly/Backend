using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projects_dolgozat.Models
{
    public class Tasks
    {
        [Key]
        public Guid TaskID { get; set; }
        [Required]
        [Column (TypeName ="varchar(255)")]
        public string? TaskDescription { get; set; }
        public virtual Users? Users { get; set; }
    }
}
