using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Portal.Application.DTOs;
using Portal.Application.Repositories;
using Portal.Domain.Entities;
using Portal.Domain.Entities.Users;

namespace Portal.Application.Features.Queries.Educations.GetEducationParticipant
{
    public class GetEducationParticipantHandler : IRequestHandler<GetEducationParticipantRequest, GetEducationParticipantResponse>
    {
        private readonly IEducationRepository _educationRepository;
        private readonly IParticipantRepository _participantRepository;
        readonly UserManager<User> _userManager;
        readonly IMapper _mapper;
        public GetEducationParticipantHandler(IEducationRepository educationRepository, IParticipantRepository participantRepository, UserManager<User> userManager, IMapper mapper)
        {
            _educationRepository = educationRepository;
            _participantRepository = participantRepository;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<GetEducationParticipantResponse> Handle(GetEducationParticipantRequest request, CancellationToken cancellationToken)
        {
            var educations = _educationRepository.Table.Include(w => w.Participants).Where(p => p.Id == request.Id).ToList();

            List<ParticipantDTO> participant = new();

            foreach (var education in educations)
            {
                foreach (var participantt in education.Participants)
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
