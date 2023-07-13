using MediatR;

namespace Portal.Application.Features.Commands.Educations.DeleteEducation
{
    public class DeleteEducationRequest : IRequest
    {
        public int Id { get; set; }
    }
}
