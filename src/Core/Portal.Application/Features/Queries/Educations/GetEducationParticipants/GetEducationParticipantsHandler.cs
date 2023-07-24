using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Portal.Application.DTOs;
using Portal.Application.Repositories;

namespace Portal.Application.Features.Queries.Educations.GetEducationParticipants
{
    public class GetEducationParticipantsHandler : IRequestHandler<GetEducationParticipantsRequest, GetEducationParticipantsResponse>
    {
        private readonly IEducationRepository _educationRepository;
        private readonly IMapper _mapper;
        public GetEducationParticipantsHandler(IEducationRepository educationRepository, IMapper mapper)
        {
            _educationRepository = educationRepository;
            _mapper = mapper;
        }

        public async Task<GetEducationParticipantsResponse> Handle(GetEducationParticipantsRequest request, CancellationToken cancellationToken)
        {
            var educations = _educationRepository.Table.Include(w => w.Participants).Where(p => p.Id == request.Id).ToList();

            List<ParticipantDTO> participant = new();

            foreach (var education in educations)
            {
                foreach (var participantt in education.Participants)
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
