using AutoMapper;
using MediatR;
using Portal.Application.DTOs;
using Portal.Application.Repositories;
using Portal.Domain.Entities;

namespace Portal.Application.Features.Queries.Educations.GetEducationById
{
    public class GetEducationByIdHandler : IRequestHandler<GetEducationByIdRequest, GetEducationByIdResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEducationRepository _educationRepository;
        public GetEducationByIdHandler(IMapper mapper, IEducationRepository educationRepository)
        {
            _mapper = mapper;
            _educationRepository = educationRepository;
        }

        public async Task<GetEducationByIdResponse> Handle(GetEducationByIdRequest request, CancellationToken cancellationToken)
        {
            Education education = await _educationRepository.GetByIdAysnc(request.Id.ToString());
            ActivityDTO result = _mapper.Map<ActivityDTO>(education);
            
            return new()
            {
                Education=result
            };
        }
    }
}
