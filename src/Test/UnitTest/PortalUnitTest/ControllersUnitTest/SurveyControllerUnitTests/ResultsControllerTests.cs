using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Portal.API.Controllers;
using Portal.Application.Features.SurveyFeatures.Queries.Results;

namespace PortalUnitTest.ControllersUnitTest.SurveyControllerUnitTests
{
    public class ResultsControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly ResultsController _resultsController;

        public ResultsControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _resultsController = new ResultsController(_mediatorMock.Object);
        }

        [Fact]
        public async Task Get_Should_Return_OkResult_With_Valid_Result()
        {
            // Arrange
            var resultId = 1;
            var request = new GetResultByIdRequest { Id = resultId };
            var response = new GetResultByIdResponse
            {
                Description = "Test",
                OptionVoteCount = 1,
                ResponseCount=1,
                SolvedCount=1,
                Id = resultId,
                Questions= null,
                Title= "Test",
                UserId= 1,
            };

            _mediatorMock.Setup(m => m.Send(request, default)).ReturnsAsync(response);

            // Act
            var result = await _resultsController.Get(request);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<GetResultByIdResponse>(okObjectResult.Value);
            Assert.Equal(response, model);
        }
    }
}
