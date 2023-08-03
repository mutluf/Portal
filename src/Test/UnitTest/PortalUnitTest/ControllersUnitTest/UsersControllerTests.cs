using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Portal.Application.Features.Commands.Users.CreateUser;
using Portal.Application.Features.Commands.Users.LoginUser;
using Portal.WebAPI.Controllers;

namespace PortalUnitTest.ControllersUnitTest
{
    public class UsersControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly UsersController _usersController;

        public UsersControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _usersController = new UsersController(_mediatorMock.Object);
        }

        [Fact]
        public async Task CreateUser_Should_Return_OkResult_With_Valid_Response()
        {
            // Arrange
            var request = new CreateUserRequest
            {
                // gerekli alanları doldur
            };
            var response = new CreateUserResponse
            {
                // sahte kullanıcı oluştur
            };

            // Mediator'den dönen cevap ayarlanıyor
            _mediatorMock.Setup(m => m.Send(request, default)).ReturnsAsync(response);

            // Act
            var result = await _usersController.CreateUser(request);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<CreateUserResponse>(okObjectResult.Value);
            Assert.Equal(response, model);
        }

        [Fact]
        public async Task LoginUser_Should_Return_OkResult_With_Valid_Response()
        {
            // Arrange
            var request = new LoginUserRequest
            {
               UserNameOrEmail="usernameOrEmail",
               Password="Password12*_"
            };
            var response = new LoginUserResponse
            {
                Message="Giriş başarılı",
                Token= new() 
                { 
                    AccessToken="EyKlsjDkmnYssdkTkmxleWmklps", 
                    Expiration= DateTime.UtcNow.AddDays(2)
                }
            };

            _mediatorMock.Setup(m => m.Send(request, default)).ReturnsAsync(response);

            // Act
            var result = await _usersController.LoginUser(request);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<LoginUserResponse>(okObjectResult.Value);
            Assert.Equal(response, model);
        }
    }
}
