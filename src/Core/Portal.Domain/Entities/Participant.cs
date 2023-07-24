using Portal.Domain.Entities.Common;
using Portal.Domain.Entities.Users;

namespace Portal.Domain.Entities
{
    public class Participant:BaseEntity
    {

        public int? UserId { get; set; }
        public User? User { get; set; }
        public ICollection<Workshop>? Workshops { get; set; }
        public ICollection<Seminar>? Seminars { get; set; }
        public ICollection<Education>? Educations { get; set; }
    }
}
