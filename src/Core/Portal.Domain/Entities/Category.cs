using Portal.Domain.Entities.Common;

namespace Portal.Domain.Entities
{
    public class Category: BaseEntity
    {
        public string Content { get; set; }
        public  ICollection<CategoryUser>? Users { get; set; }
        public ICollection<Seminar>? Seminars { get; set; }
        public ICollection<Workshop>? Workshops { get; set; }
        public ICollection<Education>? Educations { get; set; }
        public ICollection<Blog>? Blogs { get; set; }
    }
}
