using Portal.Domain.Entities.Common;

namespace Portal.Domain.Entities
{
    public class Workshop : Activity
    {

        public ICollection<Participant>? Participants { get; set; }
        public UserProfile UserProfile { get; set; }
    }
}
