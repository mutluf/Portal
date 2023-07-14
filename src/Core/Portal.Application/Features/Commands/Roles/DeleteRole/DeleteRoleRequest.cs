using MediatR;

namespace Portal.Application.Features.Commands.Roles.DeleteRole
{
    public class DeleteRoleRequest : IRequest<DeleteRoleResponse>
    {
        public string Name { get; set; }
    }
}