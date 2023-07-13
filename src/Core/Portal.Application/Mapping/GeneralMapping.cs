using AutoMapper;
using Portal.Application.Features.Commands.Users.CreateUser;
using Portal.Application.Features.Commands.Users.LoginUser;
using Portal.Domain.Entities.Users;

namespace Portal.Application.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<CreateUserRequest, User>().ReverseMap();
        }
    }
}
