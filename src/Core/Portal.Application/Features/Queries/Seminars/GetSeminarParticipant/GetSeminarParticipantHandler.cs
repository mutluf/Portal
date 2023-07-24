using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Portal.Application.DTOs;
using Portal.Application.Repositories;
using Portal.Domain.Entities.Users;

namespace Portal.Application.Features.Queries.Seminars.GetSeminarParticipant
{
    public class GetSeminarParticipantHandler : IRequestHandler<GetSeminarParticipantRequest, GetSeminarParticipantResponse>
    {
        private readonly ISeminarRepository _seminarRepository;
        private readonly IParticipantRepository _participantRepository;
        readonly UserManager<User> _userManager;
        readonly IMapper _mapper;

        public GetSeminarParticipantHandler(ISeminarRepository seminarRepository, IParticipantRepository participantRepository, UserManager<User> userManager, IMapper mapper)
        {
            _seminarRepository = seminarRepository;
            _participantRepository = participantRepository;
            _userManager = userManager;
            _mapper = mapper;
        }


        public async Task<GetSeminarParticipantResponse> Handle(GetSeminarParticipantRequest request, CancellationToken cancellationToken)
        {
            var seminars = _seminarRepository.Table.Include(w => w.Participants).Where(p => p.Id == request.Id).ToList();

            List<ParticipantDTO> participant = new();

            foreach (var seminar in seminars)
            {
                foreach (var participantt in seminar.Participants)
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
