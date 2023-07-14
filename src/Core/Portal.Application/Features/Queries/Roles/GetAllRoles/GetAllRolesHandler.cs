using MediatR;
using Portal.Application.Abstractions.Services;

namespace Portal.Application.Features.Queries.Roles.GetAllRoles
{
   
    public class GetAllRolesHandler : IRequestHandler<GetAllRolesRequest, GetAllRolesResponse>
    {
        readonly IRoleService _roleService;

        public GetAllRolesHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }
        public async Task<GetAllRolesResponse> Handle(GetAllRolesRequest request, CancellationToken cancellationToken)
        {
            var data =  _roleService.GetAllRoles();
            return new()
            {
                Datas = data,
            };
        }
    }
}
