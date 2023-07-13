using MediatR;

namespace Portal.Application.Features.Commands.Workshops.DeleteWorkshop
{
    public class DeleteWorkshopRequest : IRequest
    {
        public int Id { get; set; }
    }
}
