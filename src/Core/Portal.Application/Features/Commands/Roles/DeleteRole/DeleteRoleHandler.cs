using MediatR;
using Portal.Application.Abstractions.Services;

namespace Portal.Application.Features.Commands.Roles.DeleteRole
{
    public class DeleteRoleHandler : IRequestHandler<DeleteRoleRequest, DeleteRoleResponse>
    {
        readonly IRoleService _roleService;

        public DeleteRoleHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<DeleteRoleResponse> Handle(DeleteRoleRequest request, CancellationToken cancellationToken)
        {
            bool result = await _roleService.DeleteRole(request.Name);
            return new()
            {
                Succeeded = result,
            };
        }
    }
}
