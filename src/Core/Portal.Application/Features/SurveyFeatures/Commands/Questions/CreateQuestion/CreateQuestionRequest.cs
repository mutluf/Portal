using MediatR;
using Portal.Application.DTOs.SurveyDTOs;

namespace Portal.Application.Features.SurveyFeatures.Commands.Questions.CreateQuestion
{
    public class CreateQuestionRequest : IRequest
    {
        public QuestionDTO QuestionDTO { get; set; }
    }
}
