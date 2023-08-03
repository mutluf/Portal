using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Portal.Application.Features.Commands.Subscriptions.CreateSubscription.CreateSubscription;
using Portal.WebAPI.Controllers;

namespace PortalUnitTest.ControllersUnitTest
{
    public class SubscriptionsControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly SubscriptionsController _subscriptionsController;

        public SubscriptionsControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _subscriptionsController = new SubscriptionsController(_mediatorMock.Object);
        }

        [Fact]
        public async Task Create_Should_Return_OkResult_With_Valid_Response()
        {
            // Arrange
            var request = new CreateSubscriptionRequest
            {               
            };
            var response = new CreateSubscriptionResponse
            {                
            };

            _mediatorMock.Setup(m => m.Send(request, default)).ReturnsAsync(response);

            // Act
            var result = await _subscriptionsController.Create(request);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<CreateSubscriptionResponse>(okObjectResult.Value);
            Assert.Equal(response, model);
        }
    }
}
