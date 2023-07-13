using MediatR;

namespace Portal.Application.Features.Queries.Seminars.GetSeminarById
{
    public class GetSeminarByIdRequest : IRequest<GetSeminarByIdResponse>
    {
        public int Id { get; set; }
    }
}
