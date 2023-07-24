using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Portal.Application.DTOs;
using Portal.Application.Repositories;
using Portal.Domain.Entities;

namespace Portal.Application.Features.Queries.Participants.GetAllParticipantsByWorkshopId
{
    public class GetParticipantsByWorkshopHandler : IRequestHandler<GetParticipantsByWorkshopRequest, GetParticipantsByWorkshopResponse>
    {
        private readonly IWorkshopRepository _workshopRepository;
        private readonly IMapper _mapper;
        public GetParticipantsByWorkshopHandler(IWorkshopRepository workshopRepository, IMapper mapper)
        {

            _workshopRepository = workshopRepository;
            _mapper = mapper;
        }

        public async Task<GetParticipantsByWorkshopResponse> Handle(GetParticipantsByWorkshopRequest request, CancellationToken cancellationToken)
        {
            var workshops = _workshopRepository.Table.Include(w=> w.Participants).Where(p=> p.Id == request.Id).ToList();

            List<ParticipantDTO> participant = new();

            foreach (var workshop in workshops)
            {
                foreach (var participantt in workshop.Participants)
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
