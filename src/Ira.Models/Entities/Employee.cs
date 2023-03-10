using System.ComponentModel.DataAnnotations;

namespace Ira.Models.Entities
{
    public class Employee
    {
        [Required]
        [Key]
        public Guid Id { get; set; }

        [MaxLength(30)]
        public string CompleteName { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }
        
        public string AidCard { get; set; }
        
        public string Email { get; set; }

        public string Position { get; set; }
    }
}
