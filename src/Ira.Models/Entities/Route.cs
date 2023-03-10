using System.ComponentModel.DataAnnotations;

namespace Ira.Models.Entities
{
    public class Route
    {
        [Required]
        [Key]
        public Guid Id { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        [MaxLength(30)]
        public string Origin { get; set; }

        [MaxLength(30)]
        public string Destination { get; set; }

        [MaxLength(255)]
        public string CargoDescription { get; set; }
        
        public double CargoValue { get; set; }
    }
}
