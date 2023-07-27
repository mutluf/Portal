using Portal.Application.DTOs.SurveyDTOs;

namespace Portal.Application.Features.SurveyFeatures.Queries.Results
{
    public class GetResultByIdResponse
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int SolvedCount { get; set; }
        public int UserId { get; set; }
        public List<QuestionResponse> Questions { get; set; }
        public int ResponseCount { get; set; }
        public int OptionVoteCount { get; set; }
    }
}
