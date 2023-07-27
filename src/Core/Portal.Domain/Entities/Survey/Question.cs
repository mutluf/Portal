using Portal.Domain.Entities.Common;

namespace Portal.Domain.Entities.Survey
{
    public class Question : BaseEntity
    {
        public string? QuestionContent { get; set; }
        public string? QuestionType { get; set; }
        public int QuestionRate { get; set; }
        public Survey? Survey { get; set; }
        public int SurveyId { get; set; }
        public ICollection<Option>? Options { get; set; }

        public ICollection<AnsweredQuestion> Questions { get; set; }
    }
}
