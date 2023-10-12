using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mime;

namespace cars.Models
{
    public class Car
    {
        [Key]//primary key
        public Guid Id { get; set; }
        [Required]
        [Column(TypeName="varchar(20)")]//tipus átírás
        public string Modelname { get; set; }    

        public string? Description { get; set; }

        public DateTime Created { get; set; }
    }
}
