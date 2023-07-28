using MediatR;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Features.SurveyFeatures.Commands.Questions.CreateQuestion;
using Portal.Application.Features.SurveyFeatures.Commands.Questions.DeleteQuestion;
using Portal.Application.Features.SurveyFeatures.Queries.Questions.GetAllQuestions;

namespace Portal.API.Controllers
{
    [Route("api/questions")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public QuestionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateQuestionRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {            
            GetAllQuestionsRequest request = new();
            GetAllQuestionsResponse response = await _mediator.Send(request);
            return Ok(response.QuestionDTOs);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteQuestionRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
    }
}
