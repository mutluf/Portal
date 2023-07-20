using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Features.Commands.Subscriptions.CreateSubscription.CreateSubscription;

namespace Portal.WebAPI.Controllers
{
    [Route("api/subscriptions")]
    [ApiController]
    public class SubscriptionsController : ControllerBase
    {
        readonly IMediator _mediator;

        public SubscriptionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSubscriptionRequest request)
        {
            CreateSubscriptionResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
