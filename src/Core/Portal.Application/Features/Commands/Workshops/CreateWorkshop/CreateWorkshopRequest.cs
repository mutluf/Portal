using MediatR;
using Portal.Application.DTOs;

namespace Portal.Application.Features.Commands.Workshops.CreateWorkshop
{
    public class CreateWorkshopRequest : IRequest
    {
        public ActivityDTO? Workshop { get; set; }
    }
}
