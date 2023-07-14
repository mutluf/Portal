using MediatR;
using Portal.Application.Abstractions.Services;

namespace Portal.Application.Features.Commands.Roles.UpdateRole
{
    public class UpdateRoleHandler : IRequestHandler<UpdateRoleRequest, UpdateRoleResponse>
    {
        readonly IRoleService _roleService;

        public UpdateRoleHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<UpdateRoleResponse> Handle(UpdateRoleRequest request, CancellationToken cancellationToken)
        {
            bool result= await _roleService.UpdateRole(request.Id, request.Name);
            return new()
            {
                Succeeded = result,
            };
        }
    }
}
