using System.ComponentModel.DataAnnotations;

namespace Ira.Models.Entities
{
    public  class Notification
    {
        [Required]
        [Key]
        public Guid Id { get; set; }

        public string Message { get; set; }

        [MaxLength(150)]
        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime SentDate { get; set; }

        public bool IsSentOk { get; set; } = false;
    }
}
