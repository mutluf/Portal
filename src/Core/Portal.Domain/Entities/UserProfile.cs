using Portal.Domain.Entities.Users;

namespace Portal.Domain.Entities
{
    public class UserProfile
    {
        public User User { get; set; }
        public int UserId { get; set; }
        public ICollection<Blog> Blogs { get; set; }
        public ICollection<Education> Educations { get; set; }
        public ICollection<Seminar> Seminars { get; set; }
        public ICollection<Workshop> Workshops { get; set; }
    }
}
