using AutoMapper;
using MediatR;
using Portal.Application.Repositories.SurveyRepositories;
using Portal.Domain.Entities.Survey;

namespace Portal.Application.Features.SurveyFeatures.Commands.Questions.CreateQuestion
{
    public class CreateSurveyHandler : IRequestHandler<CreateQuestionRequest>
    {
        private readonly IMapper _mapper;
        private readonly IQuestionRepository _questionRepository;
        public CreateSurveyHandler(IMapper mapper, IQuestionRepository questionRepository)
        {
            _mapper = mapper;
            _questionRepository = questionRepository;
        }

        public async Task<Unit> Handle(CreateQuestionRequest request, CancellationToken cancellationToken)
        {
            Question question = _mapper.Map<Question>(request);
            await _questionRepository.AddAysnc(question);
            await _questionRepository.SaveAysnc();

            return Unit.Value;
        }
    }
}
