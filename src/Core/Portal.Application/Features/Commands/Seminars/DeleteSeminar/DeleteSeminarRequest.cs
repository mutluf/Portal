using MediatR;

namespace Portal.Application.Features.Commands.Seminars.DeleteSeminar
{
    public class DeleteSeminarRequest : IRequest
    {
        public int Id { get; set; }
    }
}
