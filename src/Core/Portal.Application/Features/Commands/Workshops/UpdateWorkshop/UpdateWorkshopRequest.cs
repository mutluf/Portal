using MediatR;
using Portal.Application.Features.Commands.Workshops.UpdateWorkshop;

namespace Portal.Application.Features.Workshops.UpdateWorkshop.UpdateEducation
{
    public class UpdateWorkshopRequest : IRequest<UpdateWorkshopResponse>
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsPublic { get; set; } = true;
        public bool IsCanceled { get; set; } = false;
        public DateTime StartTime { get; set; }
    }
}