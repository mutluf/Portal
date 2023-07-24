using MediatR;

namespace Portal.Application.Features.Queries.Participants.GetAllParticipantsByWorkshopId
{
    
    public class GetParticipantsByWorkshopRequest : IRequest<GetParticipantsByWorkshopResponse>
    {
        public int Id { get; set; }
    }
}