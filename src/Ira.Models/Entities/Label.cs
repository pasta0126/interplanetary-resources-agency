using System.ComponentModel.DataAnnotations;

namespace Ira.Models.Entities
{
    public class Label
    {
        [Required]
        [Key]
        public Guid Id { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }
    }
}
