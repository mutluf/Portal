using MediatR;
using Portal.Application.DTOs;

namespace Portal.Application.Features.Commands.Educations.CreateEducation
{
    public class CreateEducationRequest: IRequest
    {
        public ActivityDTO? Education { get; set; }
    }
}
