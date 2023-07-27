namespace Portal.Application.DTOs.SurveyDTOs
{
    public class AnsweredQuestionDTO
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string QuestionContent { get; set; }
        public int QuestionRate { get; set; }
        public int ResponseId { get; set; }

        public List<AnsweredOptionDTO> Options { get; set; }
    }
}
