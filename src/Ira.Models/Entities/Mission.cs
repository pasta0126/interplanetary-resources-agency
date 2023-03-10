using System.ComponentModel.DataAnnotations;

namespace Ira.Models.Entities
{
    public class Mission
    {
        [Required]
        [Key]
        public Guid Id { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public List<Label> Labels { get; set; }

        public Ship Ship { get; set; }

        public Route Route { get; set; }
    }
}
