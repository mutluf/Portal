using Portal.Application.DTOs;

namespace Portal.Application.Features.Queries.Educations.GetEducationParticipants
{
    public class GetEducationParticipantsResponse
    {
        public IList<ParticipantDTO> Participants { get; set; }
    }
}