using MediatR;
using Portal.Application.Abstractions.Services;

namespace Portal.Application.Features.Queries.Roles.GetRoleById
{

    public class GetRoleByIdHandler : IRequestHandler<GetRoleByIdRequest, GetRoleByIdResponse>
    {
        readonly IRoleService _roleService;

        public GetRoleByIdHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }
        public async Task<GetRoleByIdResponse> Handle(GetRoleByIdRequest request, CancellationToken cancellationToken)
        {
            var data = await _roleService.GetRoleById(request.Id);
            return new()
            {
                Id = data.id,
                Name = data.name,
            };
        }
    }
}
