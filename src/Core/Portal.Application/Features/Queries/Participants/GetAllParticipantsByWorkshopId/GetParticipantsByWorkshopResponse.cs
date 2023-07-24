using Portal.Application.DTOs;
using Portal.Domain.Entities;

namespace Portal.Application.Features.Queries.Participants.GetAllParticipantsByWorkshopId
{
    public class GetParticipantsByWorkshopResponse
    {
        public IList<ParticipantDTO> Participants { get; set; }
    }
}