using MediatR;
using Microsoft.AspNetCore.Identity;
using Portal.Application.Abstractions;
using Portal.Application.DTOs;
using Portal.Domain.Entities.Users;

namespace Portal.Application.Features.Commands.Users.LoginUser
{
    public class LoginUserHandler : IRequestHandler<LoginUserRequest, LoginUserResponse>
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenHandler _tokenHandler;
        public LoginUserHandler(UserManager<User> userManager, SignInManager<User> signInManager, ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
        }

        public async Task<LoginUserResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {
            User user = await _userManager.FindByNameAsync(request.UserNameOrEmail);
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(request.UserNameOrEmail);
            }
            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);


            if (result.Succeeded)
            {
                Token token = _tokenHandler.CreateToken(20);
                return new()
                {
                    Message = "Giriş yapıldı.",
                    Token = token
                };
            }
            else
            {
                return new()
                {
                    Message = "yeniden dene"
                };
            }
        }
    }
}
