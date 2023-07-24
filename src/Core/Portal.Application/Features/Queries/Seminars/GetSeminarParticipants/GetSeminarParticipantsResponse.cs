using Portal.Application.DTOs;

namespace Portal.Application.Features.Queries.Seminars.GetSeminarParticipants
{
    public class GetSeminarParticipantsResponse
    {
        public IList<ParticipantDTO> Participants { get; set; }
    }
}