using MediatR;
using Portal.Application.DTOs;

namespace Portal.Application.Features.Commands.Seminars.CreateSeminar
{
    public class CreateSeminarRequest : IRequest
    {
        public ActivityDTO? Seminar { get; set; }
    }
}
