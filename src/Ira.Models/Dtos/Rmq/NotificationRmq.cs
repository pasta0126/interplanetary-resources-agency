namespace Ira.Models.Dtos.Rmq
{
    public class NotificationRmq
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
