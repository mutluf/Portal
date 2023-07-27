using AutoMapper;
using MediatR;
using Portal.Application.DTOs.SurveyDTOs;
using Portal.Application.Repositories.SurveyRepositories;
using Portal.Domain.Entities.Survey;

namespace Portal.Application.Features.SurveyFeatures.Queries.Questions.GetAllQuestions
{
    public class GetAllQuestionsHandler : IRequestHandler<GetAllQuestionsRequest, GetAllQuestionsResponse>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;
        public GetAllQuestionsHandler(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<GetAllQuestionsResponse> Handle(GetAllQuestionsRequest request, CancellationToken cancellationToken)
        {
            IQueryable<Question> questions = _questionRepository.GetAll();
            IList<QuestionDTO> questionDTOs = _mapper.Map<IList<QuestionDTO>>(questions);

            return new()
            {
                QuestionDTOs = questionDTOs,
            };
        }
    }
}
