using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Portal.Application.Features.Commands.Users.ChangeRole;
using Portal.WebAPI.Controllers;

namespace PortalUnitTest.ControllersUnitTest
{
    public class ProfilesControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly ProfilesController _profilesController;

        public ProfilesControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _profilesController = new ProfilesController(_mediatorMock.Object);
        }

        [Fact]
        public async Task ChangeRole_Should_Return_OkResult()
        {
            // Arrange
            var request = new ChangeRoleRequest
            {
                Id = 1,
                UserRole = "Producer"
            };

            // Act
            var result = await _profilesController.ChangeRole(request);

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}
