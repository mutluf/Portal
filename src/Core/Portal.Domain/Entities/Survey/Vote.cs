using Portal.Domain.Entities.Common;

namespace Portal.Domain.Entities.Survey
{
    public class Vote : BaseEntity
    {
        public Option? Option { get; set; }
        public int? OptionId { get; set; }

        public AnsweredOption? AnsweredOption { get; set; }
        public int? AnsweredOptionId { get; set; }
    }
}
