using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Portal.Application.DTOs;
using Portal.Application.Repositories;

namespace Portal.Application.Features.Queries.Workshops.GetWorkshopParticipants
{
    public class GetWorkshopParticipantsHandler : IRequestHandler<GetWorkshopParticipantsRequest, GetWorkshopParticipantsResponse>
    {
        private readonly IWorkshopRepository _workshopRepository;
        private readonly IMapper _mapper;
        public GetWorkshopParticipantsHandler(IWorkshopRepository workshopRepository, IMapper mapper)
        {

            _workshopRepository = workshopRepository;
            _mapper = mapper;
        }

        public async Task<GetWorkshopParticipantsResponse> Handle(GetWorkshopParticipantsRequest request, CancellationToken cancellationToken)
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
