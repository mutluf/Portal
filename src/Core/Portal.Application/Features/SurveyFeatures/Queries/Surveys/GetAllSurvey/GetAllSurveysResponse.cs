using Portal.Application.DTOs.SurveyDTOs;

namespace Portal.Application.Features.SurveyFeatures.Queries.Surveys.GetAllSurvey
{
    public class GetAllSurveysResponse
    {
        public IList<SurveyDTO> SurveyDTOs { get; set; }
    }
}
