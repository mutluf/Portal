namespace Portal.Application.DTOs
{
    public class MessageUserDTO
    {
        public int UserId { get; set; }
        public int MessageId { get; set; }
        public string? MessageContent { get; set; }
        public string? UserName { get; set; }
    }
}
