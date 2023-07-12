using Portal.Domain.Entities.Common;

namespace Portal.Domain.Entities
{
    public class Blog : Activity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int ViewCount { get; set; }
        public string CreatedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsPublic { get; set; }
        public UserProfile UserProfile { get; set; }
    }
}
