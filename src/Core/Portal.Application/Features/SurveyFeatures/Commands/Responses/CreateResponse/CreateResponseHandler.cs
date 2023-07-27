using AutoMapper;
using MediatR;
using Portal.Application.Repositories.SurveyRepositories;
using Portal.Domain.Entities.Survey;

namespace Portal.Application.Features.SurveyFeatures.Commands.Responses.CreateResponse
{
    public class CreateResponseHandler : IRequestHandler<CreateResponseRequest>
    {
        private readonly IMapper _mapper;
        private readonly IResponseRepository _responseRepository;
        public CreateResponseHandler(IMapper mapper, IResponseRepository responseRepository)
        {
            _mapper = mapper;
            _responseRepository = responseRepository;
        }

        public async Task<Unit> Handle(CreateResponseRequest request, CancellationToken cancellationToken)
        {
            Response response = _mapper.Map<Response>(request.Response);


            await _responseRepository.AddAysnc(response);
            await _responseRepository.SaveAysnc();

            return Unit.Value;


        }
    }
}
