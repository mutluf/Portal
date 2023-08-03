using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Features.SurveyFeatures.Commands.Surveys.CreateSurvey;
using Portal.Application.Features.SurveyFeatures.Commands.Surveys.DeleteSurvey;
using Portal.Application.Features.SurveyFeatures.Queries.Results;
using Portal.Application.Features.SurveyFeatures.Queries.Surveys.GetAllSurvey;
using Portal.Application.Features.SurveyFeatures.Queries.Surveys.GetSurveyById;

namespace Portal.API.Controllers
{
    [Route("api/surveys")]
    [ApiController]
    //[Authorize(AuthenticationSchemes ="User")]
    public class SurveysController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SurveysController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateSurveyRequest request)
        {
            CreateSurveyResponse response =  await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {            
            GetAllSurveysRequest request = new();
            GetAllSurveysResponse response = await _mediator.Send(request);
            return Ok(response);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute]GetSurveyByIdRequest request)
        {
            GetSurveyByIdResponse response = await _mediator.Send(request);
            return Ok(response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteSurveyRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }


        [HttpGet("{id}/result")]
        public async Task<IActionResult> Get([FromRoute] GetResultByIdRequest request)
        {
            GetResultByIdResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
