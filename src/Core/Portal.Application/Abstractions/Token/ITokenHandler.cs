using Portal.Application.DTOs;

namespace Portal.Application.Abstractions
{
    public interface ITokenHandler
    {
        Token CreateToken(int minute);
    }
}
