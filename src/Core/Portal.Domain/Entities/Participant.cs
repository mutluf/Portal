using Portal.Domain.Entities.Users;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Portal.Domain.Entities
{
    public class Participant
    {
        [Key, ForeignKey(nameof(User))]
        public int Id { get; set; }
        public User? User { get; set; }
        public int ParticipantCount { get; set; }
        public ICollection<Workshop>? Workshops { get; set; }
        public ICollection<Seminar>? Seminars { get; set; }
        public ICollection<Education>? Educations { get; set; }
    }
}
