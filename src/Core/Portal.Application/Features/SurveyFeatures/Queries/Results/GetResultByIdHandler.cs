using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Portal.Application.Repositories.SurveyRepositories;
using Portal.Domain.Entities.Survey;

namespace Portal.Application.Features.SurveyFeatures.Queries.Results
{
    public class GetResultByIdHandler : IRequestHandler<GetResultByIdRequest, GetResultByIdResponse>
    {
        private readonly ISurveyRepository _surveyRepository;
        private readonly IMapper _mapper;
        private readonly IOptionRepository _optionRepository;
        public GetResultByIdHandler(ISurveyRepository surveyRepository, IMapper mapper, IOptionRepository optionRepository)
        {
            _surveyRepository = surveyRepository;
            _mapper = mapper;
            _optionRepository = optionRepository;
        }

        public async Task<GetResultByIdResponse> Handle(GetResultByIdRequest request, CancellationToken cancellationToken)
        {
            
            Survey survey = await _surveyRepository.Table.Include(question => question.Questions)
                                                         .ThenInclude(option => option.Options)
                                                         .ThenInclude(vote => vote.Votes)
                                                         .Include(response=>response.Responses)
                                                         .ThenInclude(answeredQuestion=> answeredQuestion.Questions)
                                                         .ThenInclude(answeredOption=> answeredOption.Options)
                                                         .FirstOrDefaultAsync(s => s.Id == request.Id);

            GetResultByIdResponse response= _mapper.Map<GetResultByIdResponse>(survey);
            response.ResponseCount = survey.Responses.Count();
        
            return response;
        }
    }
}
