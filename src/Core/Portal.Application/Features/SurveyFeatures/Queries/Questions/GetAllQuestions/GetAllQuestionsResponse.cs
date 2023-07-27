using Portal.Application.DTOs.SurveyDTOs;

namespace Portal.Application.Features.SurveyFeatures.Queries.Questions.GetAllQuestions
{
    public class GetAllQuestionsResponse
    {
        public IList<QuestionDTO> QuestionDTOs { get; set; }
    }
}
