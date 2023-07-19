using MediatR;

namespace Portal.Application.Features.Commands.Users.ChangeRole
{
    public class ChangeRoleRequest : IRequest
    {
        public int Id { get; set; }
        public string UserRole { get; set; }
    }
}