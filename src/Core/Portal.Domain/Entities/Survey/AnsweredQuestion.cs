using Portal.Domain.Entities.Common;

namespace Portal.Domain.Entities.Survey
{
    public class AnsweredQuestion : BaseEntity
    {
        public Response? Response { get; set; }
        public int ResponseId { get; set; }
        public ICollection<AnsweredOption>? Options { get; set; }


        public Question? Question { get; set; }
        public int QuestionId { get; set; }

    }
}
