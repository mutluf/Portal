using MediatR;

namespace Portal.Application.Features.Commands.Users.LoginUser
{
    public class LoginUserRequest : IRequest<LoginUserResponse>
    {
        public string UserNameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
