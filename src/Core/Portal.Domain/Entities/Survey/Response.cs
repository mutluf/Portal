using Portal.Domain.Entities.Common;
using Portal.Domain.Entities.Users;

namespace Portal.Domain.Entities.Survey
{
    public class Response : BaseEntity
    {
        public ICollection<AnsweredQuestion>? Questions { get; set; }
        public Survey? Survey { get; set; }
        public int SurveyId { get; set; }

        public User? User { get; set; }
        public int? UserId { get; set; }
    }
}
