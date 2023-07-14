using MediatR;
using Portal.Application.Abstractions.Services;

namespace Portal.Application.Features.Commands.Roles.CreateRole
{
    public class CreateRoleHandler : IRequestHandler<CreateRoleRequest, CreateRoleResponse>
    {
        readonly IRoleService _roleService;

        public CreateRoleHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<CreateRoleResponse> Handle(CreateRoleRequest request, CancellationToken cancellationToken)
        {
            bool result = await _roleService.CreateRole(request.Name);
            return new()
            {
                Succeeded = result,
            };
        }
    }
}
