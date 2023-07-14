using MediatR;

namespace Portal.Application.Features.Commands.Roles.UpdateRole
{
    public class UpdateRoleRequest : IRequest<UpdateRoleResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}