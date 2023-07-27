using MediatR;

namespace Portal.Application.Features.SurveyFeatures.Commands.Surveys.DeleteSurvey
{
    public class DeleteSurveyRequest : IRequest
    {
        public int Id { get; set; }
    }
}
