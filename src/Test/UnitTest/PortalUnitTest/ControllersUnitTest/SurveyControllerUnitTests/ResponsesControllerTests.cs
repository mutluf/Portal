using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Portal.API.Controllers;
using Portal.Application.Features.SurveyFeatures.Commands.Responses.CreateResponse;

namespace PortalUnitTest.ControllersUnitTest.SurveyControllerUnitTests
{
    public class ResponsesControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly ResponsesController _responsesController;

        public ResponsesControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _responsesController = new ResponsesController(_mediatorMock.Object);
        }

        [Fact]
        public async Task Post_Should_Return_OkResult()
        {
            // Arrange
            var request = new CreateResponseRequest
            {
                Response= new()
                {
                    SurveyId = 1,
                    UserId = 1,
                    Questions = null 
                }
            };

            // Act
            var result = await _responsesController.Post(request);

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}
