using Portal.Application.DTOs;

namespace Portal.Application.Features.Queries.Seminars.GetSeminarParticipant
{
    public class GetSeminarParticipantResponse
    {
        public IList<ParticipantDTO> Participants { get; set; }
    }
}