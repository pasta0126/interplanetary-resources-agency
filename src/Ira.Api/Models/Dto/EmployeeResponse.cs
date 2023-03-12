namespace Ira.Api.Models.Dto
{
    public class EmployeeResponse
    {
        public Guid Id { get; set; }
        public string CompleteName { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
    }
}
