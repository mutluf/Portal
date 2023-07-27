using MediatR;
using Portal.Application.DTOs.SurveyDTOs;

namespace Portal.Application.Features.SurveyFeatures.Commands.Responses.CreateResponse
{
    public class CreateResponseRequest:IRequest
    {
        public ResponseDTO Response { get; set; }
    }
}
