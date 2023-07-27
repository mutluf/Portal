namespace Portal.Application.DTOs.SurveyDTOs
{
    public class ResponseDTO
    {
        public int Id { get; set; }
        public int SurveyId { get; set; }
        public int? UserId { get; set; }
        public ICollection<AnsweredQuestionDTO>? Questions { get; set; }
    }
}
