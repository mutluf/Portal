using MediatR;

namespace Portal.Application.Features.SurveyFeatures.Queries.Surveys.GetSurveyById
{
    public class GetSurveyByIdRequest:IRequest<GetSurveyByIdResponse>
    {
        public int Id { get; set; }
    }
}
