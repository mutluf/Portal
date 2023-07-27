using MediatR;
using Portal.Application.Repositories.SurveyRepositories;
using Portal.Domain.Entities.Survey;

namespace Portal.Application.Features.SurveyFeatures.Commands.Questions.DeleteQuestion
{
    public class DeleteSurveyHandler : IRequestHandler<DeleteQuestionRequest>
    {
        private readonly IQuestionRepository _questionRepository;

        public DeleteSurveyHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<Unit> Handle(DeleteQuestionRequest request, CancellationToken cancellationToken)
        {
            Question question = await _questionRepository.GetByIdAysnc(request.Id.ToString());
            _questionRepository.Delete(question);
            await _questionRepository.SaveAysnc();

            return Unit.Value;
        }
    }
}
