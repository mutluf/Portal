using MediatR;
using Portal.Application.DTOs.SurveyDTOs;

namespace Portal.Application.Features.SurveyFeatures.Commands.Surveys.CreateSurvey
{
    public class CreateSurveyRequest : IRequest<CreateSurveyResponse>
    {
        public SurveyDTO Survey { get; set; }
    }
}
