using System.ComponentModel.DataAnnotations;

namespace Ira.Models.Entities
{
    public class Location
    {
        [Required]
        [Key]
        public Guid Id { get; set; }

        [MaxLength(30)]
        public string Cluster { get; set; }

        [MaxLength(30)]
        public string Nebula { get; set; }

        [MaxLength(30)]
        public string Galaxy { get; set; }

        [MaxLength(30)]
        public string Planet { get; set; }

        [MaxLength(30)]
        public string Comments { get; set; }
    }
}
