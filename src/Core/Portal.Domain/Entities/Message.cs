using Portal.Domain.Entities.Common;
using Portal.Domain.Entities.Users;

namespace Portal.Domain.Entities
{
    public class Message: BaseEntity
    {
        public string MessageContent { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Seminar>? Seminars { get; set; }
        public ICollection<Workshop>? Workshops { get; set; }
        public ICollection<Education>? Educations { get; set; }
        public ICollection<Blog>? Blogs { get; set; }
    }
}
