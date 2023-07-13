using AutoMapper;
using MediatR;
using Portal.Application.DTOs;
using Portal.Application.Repositories;
using Portal.Domain.Entities;

namespace Portal.Application.Features.Queries.Seminars.GetSeminarById
{
    public class GetSeminarByIdHandler : IRequestHandler<GetSeminarByIdRequest, GetSeminarByIdResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISeminarRepository _seminarRepository;
        public GetSeminarByIdHandler(IMapper mapper, ISeminarRepository seminarRepository)
        {
            _mapper = mapper;
            _seminarRepository = seminarRepository;
        }
        
        public async Task<GetSeminarByIdResponse> Handle(GetSeminarByIdRequest request, CancellationToken cancellationToken)
        {
            Seminar seminar = await _seminarRepository.GetByIdAysnc(request.Id.ToString());
            ActivityDTO result = _mapper.Map<ActivityDTO>(seminar);
            
            return new()
            {
                Seminar = result
            };
        }
    }
}
