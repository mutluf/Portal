using Portal.Domain.Entities.Common;
using Portal.Domain.Entities.Users;

namespace Portal.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public string? Content { get; set; }
        public User? User { get; set; }
        public int UserId { get; set; }
        public ICollection<Seminar>? Seminars { get; set; }
        public ICollection<Workshop>? Workshops { get; set; }
        public ICollection<Education>? Educations { get; set; }
        public ICollection<Blog>? Blogs { get; set; }
    }
}
