using Portal.Domain.Entities.Common;

namespace Portal.Domain.Entities
{
    public class Activity: BaseEntity
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsPublic { get; set; } = true;
        public bool IsCanceled { get; set; } = false;
        public int ParticipantCount { get; set; }
        public DateTime StartTime { get; set; }
    }
}
