using Portal.Application.DTOs;

namespace Portal.Application.Features.Commands.Users.LoginUser
{
    public class LoginUserResponse
    {
        public string Message { get; set; }
        public Token Token { get; set; }
    }
}
