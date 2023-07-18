using MediatR;

namespace Portal.Application.Features.Commands.Subscriptions.CreateSubscription.CreateSubscription
{
    public class CreateSubscriptionRequest : IRequest<CreateSubscriptionResponse>
    {
        public int UserId { get; set; }
        public int CategoryId { get; set; }
    }
}