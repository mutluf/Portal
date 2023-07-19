using Portal.Application.DTOs;
using Portal.Domain.Entities.Users;

namespace Portal.Application.Abstractions
{
    public interface ITokenHandler
    {
        Token CreateToken(int minute, User user);
    }
}
