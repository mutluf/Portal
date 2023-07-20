using AutoMapper;
using Portal.Application.DTOs;
using Portal.Application.Features.Commands.Categories.CreateCategory;
using Portal.Application.Features.Commands.Educations.CreateEducation;
using Portal.Application.Features.Commands.Educations.UpdateEducation;
using Portal.Application.Features.Commands.Seminars.CreateSeminar;
using Portal.Application.Features.Commands.Seminars.UpdateSeminar;
using Portal.Application.Features.Commands.Users.CreateUser;
using Portal.Application.Features.Commands.Workshops.CreateWorkshop;
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

            CreateMap<CreateEducationRequest, Education>().ReverseMap();
            CreateMap<CreateWorkshopRequest, Workshop>().ReverseMap();
            CreateMap<CreateSeminarRequest, Seminar>().ReverseMap();

            CreateMap<ParticipantDTO, Participant>().ReverseMap();

            CreateMap<CreateCategoryRequest, Category>().ReverseMap();

            CreateMap<UpdateEducationRequest, Education>().ReverseMap(); 
            CreateMap<UpdateSeminarRequest, Seminar>().ReverseMap(); 
          
        }
    }
}
