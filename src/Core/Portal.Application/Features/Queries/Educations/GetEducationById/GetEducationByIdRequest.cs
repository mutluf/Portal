using MediatR;

namespace Portal.Application.Features.Queries.Educations.GetEducationById
{
    public class GetEducationByIdRequest: IRequest<GetEducationByIdResponse>
    {
        public int Id { get; set; }
    }
}
