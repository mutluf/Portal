using MediatR;

namespace Portal.Application.Features.Queries.Workshops.GetWorkshopParticipant
{
    public class GetWorkshopParticipantRequest : IRequest<GetWorkshopParticipantResponse>
    {
        public int Id { get; set; }
        public string? Word { get; set; }   
    }
}