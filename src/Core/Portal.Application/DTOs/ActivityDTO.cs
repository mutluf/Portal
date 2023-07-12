using Portal.Domain.Entities;

namespace Portal.Application.DTOs
{
    public class ActivityDTO
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsPublic { get; set; } = true;
        public bool IsCanceled { get; set; } = false;
        public DateTime StartTime { get; set; }
        public ICollection<ParticipantDTO>? Participants { get; set; }
        public int UserProfileId { get; set; }
    }
}
