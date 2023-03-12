namespace Ira.Rmq.Producer.Model
{
    public class NotificationRmq
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
