using AutoMapper;
using MediatR;
using Portal.Application.Features.Commands.Seminars.UpdateSeminar;
using Portal.Application.Repositories;
using Portal.Domain.Entities;

namespace Portal.Application.Features.Commands.Seminars.UpdateSeminar
{
    public class UpdateSeminarHandler : IRequestHandler<UpdateSeminarRequest, UpdateSeminarResponse>
    {
        private readonly ISeminarRepository _seminarRepository;
        private readonly IMapper _mapper;
        public UpdateSeminarHandler(ISeminarRepository seminarRepository, IMapper mapper)
        {
            _seminarRepository = seminarRepository;
            _mapper = mapper;
        }

        public async Task<UpdateSeminarResponse> Handle(UpdateSeminarRequest request, CancellationToken cancellationToken)
        {
            Seminar seminar = _mapper.Map<Seminar>(request);
            _seminarRepository.Update(seminar);
            await _seminarRepository.SaveAysnc();

            return new()
            {
                Message = "Başarıyla güncellendi"
            };
        }
    }
}
