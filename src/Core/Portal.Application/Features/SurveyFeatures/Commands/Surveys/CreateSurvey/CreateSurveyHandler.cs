using AutoMapper;
using MediatR;
using Portal.Application.Repositories.SurveyRepositories;
using Portal.Domain.Entities.Survey;

namespace Portal.Application.Features.SurveyFeatures.Commands.Surveys.CreateSurvey
{
    public class CreateSurveyHandler : IRequestHandler<CreateSurveyRequest, CreateSurveyResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISurveyRepository _surveyRepository;
        public CreateSurveyHandler(IMapper mapper, ISurveyRepository surveyRepository)
        {
            _mapper = mapper;
            _surveyRepository = surveyRepository;
        }

        public async Task<CreateSurveyResponse> Handle(CreateSurveyRequest request, CancellationToken cancellationToken)
        {
            Survey survey = _mapper.Map<Survey>(request.Survey);
                      
            await _surveyRepository.AddAysnc(survey);           
            await _surveyRepository.SaveAysnc();

            int id = survey.Id;
            return new()
            {
                Id = id,
            };
        }
    }
}
