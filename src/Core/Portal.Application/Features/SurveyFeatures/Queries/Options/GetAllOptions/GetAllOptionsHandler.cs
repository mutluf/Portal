using AutoMapper;
using MediatR;
using Portal.Application.DTOs.SurveyDTOs;
using Portal.Application.Repositories.SurveyRepositories;
using Portal.Domain.Entities.Survey;

namespace Portal.Application.Features.SurveyFeatures.Queries.Options.GetAllOptions
{
    public class GetAllSurveysHandler : IRequestHandler<GetAllOptionsRequest, GetAllOptionsResponse>
    {
        private readonly IOptionRepository _optionRepository;
        private readonly IMapper _mapper;
        public GetAllSurveysHandler(IOptionRepository optionRepository, IMapper mapper)
        {
            _optionRepository = optionRepository;
            _mapper = mapper;
        }

        public async Task<GetAllOptionsResponse> Handle(GetAllOptionsRequest request, CancellationToken cancellationToken)
        {
            IQueryable<Option> options = _optionRepository.GetAll();
            IList<OptionDTO> optionDTOs = _mapper.Map<IList<OptionDTO>>(options);

            return new()
            {
                OptionDTOs = optionDTOs,
            };
        }
    }
}
