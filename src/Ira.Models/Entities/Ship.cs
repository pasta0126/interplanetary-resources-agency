using System.ComponentModel.DataAnnotations;

namespace Ira.Models.Entities
{
    public class Ship
    {
        [Required]
        [Key]
        public Guid Id { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        [MaxLength(255)]
        public string Type { get; set; }

        public Crew Crew { get; set; }
    }
}
