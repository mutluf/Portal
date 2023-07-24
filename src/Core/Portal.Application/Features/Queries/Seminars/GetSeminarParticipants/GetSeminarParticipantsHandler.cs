using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Portal.Application.DTOs;

using Portal.Application.Repositories;
using Portal.Domain.Entities;

namespace Portal.Application.Features.Queries.Seminars.GetSeminarParticipants
{
    public class GetSeminarParticipantsHandler : IRequestHandler<GetSeminarParticipantsRequest, GetSeminarParticipantsResponse>
    {
        private readonly ISeminarRepository _seminarRepository;
        private readonly IMapper _mapper;
        public GetSeminarParticipantsHandler(ISeminarRepository seminarRepository, IMapper mapper)
        {

            _seminarRepository = seminarRepository;
            _mapper = mapper;
        }

        public async Task<GetSeminarParticipantsResponse> Handle(GetSeminarParticipantsRequest request, CancellationToken cancellationToken)
        {
            var seminars = _seminarRepository.Table.Include(w=> w.Participants).Where(p=> p.Id == request.Id).ToList();

            List<ParticipantDTO> participant = new();

            foreach (var seminar in seminars)
            {
                foreach (var participantt in seminar.Participants)
                {
                    var par = _mapper.Map<ParticipantDTO>(participantt);
                    participant.Add(par);
                }
                
            }
            return new()
            {
                Participants = participant,
            };
        }
    }
}
