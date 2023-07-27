using MediatR;

namespace Portal.Application.Features.SurveyFeatures.Commands.Questions.DeleteQuestion
{
    public class DeleteQuestionRequest : IRequest
    {
        public int Id { get; set; }
    }
}
