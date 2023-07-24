using MediatR;

namespace Portal.Application.Features.Queries.Seminars.GetSeminarParticipants
{
    
    public class GetSeminarParticipantsRequest : IRequest<GetSeminarParticipantsResponse>
    {
        public int Id { get; set; }
    }
}