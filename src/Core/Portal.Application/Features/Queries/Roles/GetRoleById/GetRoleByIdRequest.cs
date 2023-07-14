using MediatR;

namespace Portal.Application.Features.Queries.Roles.GetRoleById
{
    public class GetRoleByIdRequest : IRequest<GetRoleByIdResponse>
    {
        public string Id { get; set; }
    }
}