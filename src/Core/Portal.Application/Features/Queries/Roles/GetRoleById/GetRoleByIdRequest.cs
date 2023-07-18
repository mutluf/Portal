using MediatR;

namespace Portal.Application.Features.Queries.Roles.GetRoleById
{
    public class GetRoleByIdRequest : IRequest<GetRoleByIdResponse>
    {
        public int Id { get; set; }
    }
}