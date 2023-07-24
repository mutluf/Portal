using MediatR;

namespace Portal.Application.Features.Queries.Educations.GetEducationParticipant
{
    public class GetEducationParticipantRequest: IRequest<GetEducationParticipantResponse>
    {
        public int Id { get; set; }
        public string Word { get; set; }
    }
}