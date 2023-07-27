namespace Portal.Application.DTOs.SurveyDTOs
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        public string QuestionContent { get; set; }
        public string? QuestionType { get; set; }
        public int QuestionRate { get; set; }
        public List<OptionDTO> Options { get; set; }
        
    }
}
