using MediatR;

namespace Portal.Application.Features.Queries.Workshops.GetWorkshopParticipants
{
    
    public class GetWorkshopParticipantsRequest : IRequest<GetWorkshopParticipantsResponse>
    {
        public int Id { get; set; }
    }
}