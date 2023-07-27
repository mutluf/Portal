using AutoMapper;
using Portal.Application.DTOs;
using Portal.Application.DTOs.SurveyDTOs;
using Portal.Application.Features.Commands.Categories.CreateCategory;
using Portal.Application.Features.Commands.Educations.CreateEducation;
using Portal.Application.Features.Commands.Educations.UpdateEducation;
using Portal.Application.Features.Commands.Seminars.CreateSeminar;
using Portal.Application.Features.Commands.Seminars.UpdateSeminar;
using Portal.Application.Features.Commands.Users.CreateUser;
using Portal.Application.Features.Commands.Users.LoginUser;
using Portal.Application.Features.Commands.Workshops.CreateWorkshop;
using Portal.Application.Features.SurveyFeatures.Queries.Results;
using Portal.Domain.Entities;
using Portal.Domain.Entities.Survey;
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


            //survey mappings
            CreateMap<GetResultByIdResponse, Survey>().ReverseMap();

            CreateMap<Survey, SurveyDTO>().ForMember(s => s.Questions, o => o.MapFrom(a => a.Questions)).ReverseMap();

            CreateMap<Question, QuestionDTO>().ForMember(s => s.Options, o => o.MapFrom(a => a.Options)).ReverseMap();

            CreateMap<Option, OptionDTO>().ReverseMap();


            CreateMap<Response, ResponseDTO>().ForMember(s => s.Questions, o => o.MapFrom(a => a.Questions)).ReverseMap();
            CreateMap<AnsweredQuestionDTO, AnsweredQuestion>().ForMember(s => s.Options, o => o.MapFrom(a => a.Options)).ReverseMap();
            CreateMap<AnsweredOption, AnsweredOptionDTO>().ReverseMap();
            CreateMap<Vote, VoteDTO>().ReverseMap();

            CreateMap<AnsweredOption, AnsweredOptionDTO>().ReverseMap();

            CreateMap<CreateUserRequest, User>().ReverseMap();
            CreateMap<LoginUserRequest, User>().ReverseMap();

            CreateMap<Survey, SurveyResponse>().ForMember(s => s.Questions, o => o.MapFrom(a => a.Questions)).ReverseMap();

            CreateMap<Question, QuestionResponse>().ForMember(s => s.Options, o => o.MapFrom(a => a.Options)).ReverseMap();

            CreateMap<Option, OptionResponse>().ForMember(s => s.AnsweredOptions, o => o.MapFrom(a => a.AnsweredOptions)).ReverseMap();



            CreateMap<Survey, GetResultByIdResponse>().ForMember(s => s.Questions, o => o.MapFrom(a => a.Questions)).ReverseMap();

            CreateMap<Question, QuestionDTO>().ForMember(s => s.Options, o => o.MapFrom(a => a.Options)).ReverseMap();

            CreateMap<Option, OptionDTO>().ReverseMap();

        }
    }
}
