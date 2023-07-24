using Portal.Application.DTOs;

namespace Portal.Application.Features.Queries.Workshops.GetWorkshopParticipant
{
    public class GetWorkshopParticipantResponse
    {
        public IList<ParticipantDTO> Participants { get; set; }

    }
}