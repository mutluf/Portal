using MediatR;

namespace Portal.Application.Features.SurveyFeatures.Commands.Options.DeleteOption
{
    public class DeleteOptionRequest : IRequest
    {
        public int Id { get; set; }
    }
}
