using Portal.Domain.Entities.Common;

namespace Portal.Domain.Entities.Survey
{
    public class AnsweredOption : BaseEntity
    {
        public string? OptionContent { get; set; }
        public Option? Option { get; set; }
        public int OptionId { get; set; }
        public AnsweredQuestion? Question { get; set; }
        public int? QuestionId { get; set; }
        public ICollection<Vote>? Votes { get; set; }
    }
}
