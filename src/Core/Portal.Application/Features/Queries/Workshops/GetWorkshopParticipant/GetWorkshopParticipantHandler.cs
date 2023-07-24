using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Portal.Application.DTOs;
using Portal.Application.Repositories;
using Portal.Domain.Entities.Users;

namespace Portal.Application.Features.Queries.Workshops.GetWorkshopParticipant
{
    public class GetWorkshopParticipantHandler : IRequestHandler<GetWorkshopParticipantRequest, GetWorkshopParticipantResponse>
    {
        private readonly IWorkshopRepository _workshopRepository;
        private readonly IParticipantRepository _participantRepository;
        readonly UserManager<User> _userManager;
        readonly IMapper _mapper;
        public GetWorkshopParticipantHandler(IWorkshopRepository workshopRepository, IParticipantRepository participantRepository, UserManager<User> userManager, IMapper mapper)
        {
            _workshopRepository = workshopRepository;
            _participantRepository = participantRepository;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<GetWorkshopParticipantResponse> Handle(GetWorkshopParticipantRequest request, CancellationToken cancellationToken)
        {
            var workshops = _workshopRepository.Table.Include(w => w.Participants).Where(p => p.Id == request.Id).ToList();

            List<ParticipantDTO> participant = new();

            foreach (var workshop in workshops)
            {
                foreach (var participantt in workshop.Participants)
                {
                    var par = _mapper.Map<ParticipantDTO>(participantt);

                    var user = await _userManager.FindByIdAsync(par.UserId.ToString());
                    string fullname = par.FullName = user.Name + user.Surname;
                    if (fullname.Contains(request.Word))
                    {
                        participant.Add(par);
                    }
                }

            }
            return new()
            {
                Participants = participant,
            };
        }
    }
}
