namespace Ira.Api.Models.Dto
{
    public class SendEmailRequest
    {
        public List<string> To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}
