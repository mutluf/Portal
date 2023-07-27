using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Portal.Application.DTOs.SurveyDTOs;
using Portal.Application.Repositories.SurveyRepositories;
using Portal.Domain.Entities.Survey;

namespace Portal.Application.Features.SurveyFeatures.Queries.Surveys.GetAllSurvey
{
    public class GetAllSurveysHandler : IRequestHandler<GetAllSurveysRequest, GetAllSurveysResponse>
    {
        private readonly ISurveyRepository _surveyRepository;
        private readonly IMapper _mapper;
        public GetAllSurveysHandler(ISurveyRepository surveyRepository, IMapper mapper)
        {
            _surveyRepository = surveyRepository;
            _mapper = mapper;
        }

        public async Task<GetAllSurveysResponse> Handle(GetAllSurveysRequest request, CancellationToken cancellationToken)
        {
            List<Survey> surveys = _surveyRepository.Table.Include(question=>question.Questions)
                                                          .ThenInclude(option=>option.Options).ToList();

            IList<SurveyDTO> surveyDTOs = _mapper.Map<IList<SurveyDTO>>(surveys);

            return new()
            {
                SurveyDTOs = surveyDTOs,
            };
        }
    }
}
