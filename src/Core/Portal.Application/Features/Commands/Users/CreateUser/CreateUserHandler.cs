using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Portal.Domain.Entities.Users;

namespace Portal.Application.Features.Commands.Users.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        public CreateUserHandler(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            User user = _mapper.Map<User>(request);
            IdentityResult result = await _userManager.CreateAsync(user, request.Password);

            List<string> errors = new List<string>();

            foreach (var error in result.Errors)
            {
                errors.Add(error.Description);
            }

            if (result.Succeeded)
            {
                return new()
                {
                    Message = "Kayıt başarılı!"
                };
            }
            else
            {
                return new()
                {
                    Errors = errors
                };
            }
        }
    }
}
