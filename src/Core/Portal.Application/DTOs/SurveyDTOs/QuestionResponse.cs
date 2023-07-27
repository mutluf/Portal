namespace Portal.Application.DTOs.SurveyDTOs
{
    public class QuestionResponse
    {
        public int Id { get; set; }
        public string QuestionContent { get; set; }
        public string? QuestionType { get; set; }
        public int QuestionRate { get; set; }
        public List<OptionResponse> Options { get; set; }
    }
}
