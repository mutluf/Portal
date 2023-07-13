using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Portal.Application.Abstractions;
using Portal.Application.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Portal.Infrastructure.Services
{
    public class TokenHandler : ITokenHandler
    {
        readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Token CreateToken(int minute)
        {
            Token token = new Token();
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));
            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);
            token.Expiration = DateTime.Now.AddMinutes(minute);

            JwtSecurityToken securityToken = new(
               audience: _configuration["Token:Audience"],
               issuer: _configuration["Token:Issuer"],
               expires: token.Expiration,
               notBefore: DateTime.Now,
               signingCredentials: signingCredentials
               );

            JwtSecurityTokenHandler tokenHandler = new();
            token.AccessToken = tokenHandler.WriteToken(securityToken);
            return token;
        }
    }
}
