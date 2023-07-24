using Portal.Application.DTOs;

namespace Portal.Application.Features.Queries.Workshops.GetWorkshopParticipants
{
    public class GetWorkshopParticipantsResponse
    {
        public IList<ParticipantDTO> Participants { get; set; }
    }
}