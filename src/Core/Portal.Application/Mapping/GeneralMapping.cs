using AutoMapper;
using Portal.Application.DTOs;
using Portal.Application.Features.Commands.Users.CreateUser;
using Portal.Domain.Entities;
using Portal.Domain.Entities.Users;

namespace Portal.Application.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<CreateUserRequest, User>().ReverseMap();
            CreateMap<BlogDTO, Blog>().ReverseMap();
        }
    }
}
