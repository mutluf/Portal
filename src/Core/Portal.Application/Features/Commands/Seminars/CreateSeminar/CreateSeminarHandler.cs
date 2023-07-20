using AutoMapper;
using MediatR;
using Portal.Application.Repositories;
using Portal.Domain.Entities;

namespace Portal.Application.Features.Commands.Seminars.CreateSeminar
{
    public class CreateSeminarHandler : IRequestHandler<CreateSeminarRequest>
    {
        private readonly IMapper _mapper;
        private readonly ISeminarRepository _seminarRepository;
        public CreateSeminarHandler(IMapper mapper, ISeminarRepository seminarRepository)
        {
            _mapper = mapper;
            _seminarRepository = seminarRepository;
        }

        public async Task<Unit> Handle(CreateSeminarRequest request, CancellationToken cancellationToken)
        {
            Seminar seminar = _mapper.Map<Seminar>(request);
            List<Participant> participants = new();
            seminar.Participants = participants;

            await _seminarRepository.AddAysnc(seminar);
            await _seminarRepository.SaveAysnc();

            return Unit.Value;
        }
    }
}
