using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Portal.Application.DTOs.SurveyDTOs;
using Portal.Application.Repositories.SurveyRepositories;
using Portal.Domain.Entities.Survey;

namespace Portal.Application.Features.SurveyFeatures.Queries.Surveys.GetSurveyById
{
    public class GetSurveyByIdHandler : IRequestHandler<GetSurveyByIdRequest, GetSurveyByIdResponse>
    {
        private readonly ISurveyRepository _surveyRepository;
        private readonly IMapper _mapper;               
        public GetSurveyByIdHandler(ISurveyRepository surveyRepository, IMapper mapper)
        {
            _surveyRepository = surveyRepository;
            _mapper = mapper;
        }

        public async Task<GetSurveyByIdResponse> Handle(GetSurveyByIdRequest request, CancellationToken cancellationToken)
        {

            Survey survey = await _surveyRepository.Table.Include(q => q.Questions).ThenInclude(o => o.Options).ThenInclude(v=>v.Votes).FirstOrDefaultAsync(s=>s.Id==request.Id);


            SurveyResponse dto= _mapper.Map<SurveyResponse>(survey);

            return new()
            {
               Survey= dto,
            };
        }
    }
}
