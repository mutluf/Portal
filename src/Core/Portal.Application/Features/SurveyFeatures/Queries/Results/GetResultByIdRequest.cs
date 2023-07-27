using MediatR;

namespace Portal.Application.Features.SurveyFeatures.Queries.Results
{
    public class GetResultByIdRequest:IRequest<GetResultByIdResponse>
    {
        public int Id { get; set; }
    }
}
