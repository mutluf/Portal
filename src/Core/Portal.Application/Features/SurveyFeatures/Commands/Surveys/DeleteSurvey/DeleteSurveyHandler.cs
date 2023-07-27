using MediatR;
using Portal.Application.Repositories.SurveyRepositories;
using Portal.Domain.Entities.Survey;

namespace Portal.Application.Features.SurveyFeatures.Commands.Surveys.DeleteSurvey
{
    public class DeleteSurveyHandler : IRequestHandler<DeleteSurveyRequest>
    {
        private readonly ISurveyRepository _surveyRepository;

        public DeleteSurveyHandler(ISurveyRepository surveyRepository)
        {
            _surveyRepository = surveyRepository;
        }

        public async Task<Unit> Handle(DeleteSurveyRequest request, CancellationToken cancellationToken)
        {
            Survey survey = await _surveyRepository.GetByIdAysnc(request.Id.ToString());
            _surveyRepository.Delete(survey);
            await _surveyRepository.SaveAysnc();

            return Unit.Value;
        }
    }
}
