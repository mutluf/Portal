using MediatR;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Features.SurveyFeatures.Commands.Options.CreateOption;
using Portal.Application.Features.SurveyFeatures.Commands.Options.DeleteOption;
using Portal.Application.Features.SurveyFeatures.Queries.Options.GetAllOptions;

namespace Portal.API.Controllers
{
    [Route("api/options")]
    [ApiController]
    public class OptionsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OptionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateOptionRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {            
            GetAllOptionsRequest request = new();
            GetAllOptionsResponse response = await _mediator.Send(request);
            return Ok(response.OptionDTOs);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteOptionRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
    }
}
