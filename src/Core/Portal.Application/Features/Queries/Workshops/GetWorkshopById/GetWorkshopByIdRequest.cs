using MediatR;

namespace Portal.Application.Features.Queries.Workshops.GetWorkshopById
{
    public class GetWorkshopByIdRequest : IRequest<GetWorkshopByIdResponse>
    {
        public int Id { get; set; }
    }
}
