using Portal.Domain.Entities.Users;

namespace Portal.Application.DTOs
{
    public class ParticipantDTO
    {
        public int? Id { get; set; }
        public string? FullName { get; set; }
        public int? UserId { get; set; }
    }
}
