namespace Portal.Application.DTOs.SurveyDTOs
{
    public class SurveyDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int SolvedCount { get; set; }
        public int UserId { get; set; }
        public List<QuestionDTO> Questions { get; set; }
    }
}
