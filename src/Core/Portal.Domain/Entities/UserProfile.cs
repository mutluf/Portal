using Portal.Domain.Entities.Common;
using Portal.Domain.Entities.Users;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Portal.Domain.Entities
{
    public class UserProfile:BaseEntity
    {
        public int? UserId { get; set; }
        public User? User { get; set; }
        public string? UserRole { get; set; }
        public ICollection<Blog>? Blogs { get; set; }
        public ICollection<Education>? Educations { get; set; }
        public ICollection<Seminar>? Seminars { get; set; }
        public ICollection<Workshop>? Workshops { get; set; }
    }
}
