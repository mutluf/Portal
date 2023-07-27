using Portal.Domain.Entities.Common;
using Portal.Domain.Entities.Users;

namespace Portal.Domain.Entities.Survey
{
    public class Survey : BaseEntity
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public int SolvedCount { get; set; }
        public User? User { get; set; }
        public int UserId { get; set; }
        public ICollection<Question>? Questions { get; set; }
        public ICollection<Response>? Responses { get; set; }

    }
}
