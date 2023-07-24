using MediatR;

namespace Portal.Application.Features.Queries.Educations.GetEducationParticipants
{
    public class GetEducationParticipantsRequest : IRequest<GetEducationParticipantsResponse>
    {
        public int Id { get; set; }
    }
}