using MediatR;
using Microsoft.AspNetCore.Identity;
using Portal.Domain.Entities.Users;

namespace Portal.Application.Features.Commands.Users.ChangeRole
{
    public class ChangeRoleHandler : IRequestHandler<ChangeRoleRequest>
    {
        private readonly UserManager<User> _userManager;

        public ChangeRoleHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Unit> Handle(ChangeRoleRequest request, CancellationToken cancellationToken)
        {
            User user = await _userManager.FindByIdAsync(request.Id.ToString());
            IList<string> roles = await _userManager.GetRolesAsync(user);


                foreach (var role in roles)
                {
                    if (roles.Count == 1)
                    {
                    await _userManager.AddToRoleAsync(user, request.UserRole);
                }
                    else
                    {
                        if (role != "Participant")
                        {
                            if (role != request.UserRole)
                            {
                                await _userManager.RemoveFromRoleAsync(user, role);
                                await _userManager.AddToRoleAsync(user, request.UserRole);
                            }
                        }
                    }
                }
           
            return Unit.Value;
        }
    }
}
