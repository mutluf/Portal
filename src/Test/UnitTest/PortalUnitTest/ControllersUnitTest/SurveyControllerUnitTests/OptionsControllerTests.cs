using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Portal.API.Controllers;
using Portal.Application.DTOs.SurveyDTOs;
using Portal.Application.Features.SurveyFeatures.Commands.Options.CreateOption;
using Portal.Application.Features.SurveyFeatures.Commands.Options.DeleteOption;
using Portal.Application.Features.SurveyFeatures.Queries.Options.GetAllOptions;

namespace PortalUnitTest.ControllersUnitTest.SurveyControllerUnitTests
{
    public class OptionsControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly OptionsController _optionsController;

        public OptionsControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _optionsController = new OptionsController(_mediatorMock.Object);
        }

        [Fact]
        public async Task Post_Should_Return_OkResult()
        {
            // Arrange
            var request = new CreateOptionRequest
            {
                OptionDTO= new()
                {
                    OptionContent="Content",
                    VoteAmount=9
                }
            };

            // Act
            var result = await _optionsController.Post(request);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Get_Should_Return_OkResult_With_Valid_Options()
        {
            // Arrange
            var request = new GetAllOptionsRequest();
            var response = new GetAllOptionsResponse
            {
                OptionDTOs = new List<OptionDTO>
                {
                    
                }
            };

            _mediatorMock.Setup(m => m.Send(request, default)).ReturnsAsync(response);

            // Act
            var result = await _optionsController.Get();

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<List<OptionDTO>>(okObjectResult.Value);
            Assert.Equal(response.OptionDTOs, model);
        }

        [Fact]
        public async Task Delete_Should_Return_OkResult()
        {
            // Arrange
            var optionId = 1;
            var request = new DeleteOptionRequest { Id = optionId };

            // Act
            var result = await _optionsController.Delete(request);

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}
