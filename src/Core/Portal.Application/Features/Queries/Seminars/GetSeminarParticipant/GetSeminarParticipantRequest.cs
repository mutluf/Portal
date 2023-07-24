using MediatR;

namespace Portal.Application.Features.Queries.Seminars.GetSeminarParticipant
{
    public class GetSeminarParticipantRequest : IRequest<GetSeminarParticipantResponse>
    {
        public int Id { get; set; }
        public string? Word { get; set; }
    }
}