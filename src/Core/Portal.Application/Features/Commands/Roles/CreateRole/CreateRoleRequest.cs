using MediatR;

namespace Portal.Application.Features.Commands.Roles.CreateRole
{
    public class CreateRoleRequest : IRequest<CreateRoleResponse>
    {
        public string Name { get; set; }
    }
}