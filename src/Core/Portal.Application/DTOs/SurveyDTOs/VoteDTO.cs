namespace Portal.Application.DTOs.SurveyDTOs
{
    public class VoteDTO
    {
        public int Id { get; set; }
        public int? OptionId { get; set; }
        public int? AnsweredOptionId { get; set; }
    }
}
