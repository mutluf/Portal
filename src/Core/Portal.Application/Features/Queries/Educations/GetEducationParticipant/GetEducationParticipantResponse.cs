using Portal.Application.DTOs;

namespace Portal.Application.Features.Queries.Educations.GetEducationParticipant
{
    public class GetEducationParticipantResponse
    {
        public IList<ParticipantDTO> Participants { get; set; }
    }
}