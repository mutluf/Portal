using MediatR;
using Portal.Application.DTOs.SurveyDTOs;

namespace Portal.Application.Features.SurveyFeatures.Commands.Options.CreateOption
{
    public class CreateOptionRequest : IRequest
    {
        public OptionDTO OptionDTO { get; set; }
    }
}
