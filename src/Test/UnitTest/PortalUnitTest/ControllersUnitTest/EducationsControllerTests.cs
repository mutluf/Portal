using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Portal.Application.Features.Commands.Educations.CreateEducation;
using Portal.Application.Features.Commands.Educations.DeleteEducation;
using Portal.Application.Features.Commands.Educations.UpdateEducation;
using Portal.Application.Features.Queries.Educations.GetEducationById;
using Portal.Application.Features.Queries.Educations.GetEducationParticipant;
using Portal.WebAPI.Controllers;

namespace PortalUnitTest.ControllersUnitTest
{
    public class EducationsControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly EducationsController _educationsController;

        public EducationsControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _educationsController = new EducationsController(_mediatorMock.Object);
        }

        [Fact]
        public async Task Create_Should_Return_OkResult()
        {
            // Arrange
            var request = new CreateEducationRequest { 
                Title="Unit",
                Description="Deneme",
                IsCanceled=false,
                IsPublic=false,
                StartTime=DateTime.Now,
                UserProfileId= 0
            };

            // Act
            var result = await _educationsController.Create(request);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Get_Should_Return_OkResult_With_Valid_Education()
        {
            // Arrange
            var educationId = 1;
            var request = new GetEducationByIdRequest { Id = educationId };
            var education = new GetEducationByIdResponse { };

            // Mediator'den dönen cevap ayarlanıyor
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetEducationByIdRequest>(), default)).ReturnsAsync(education);

            // Act
            var result = await _educationsController.Get(request);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<GetEducationByIdResponse>(okObjectResult.Value);
            Assert.Equal(education, model);
        }

        [Fact]
        public async Task Delete_Should_Return_OkResult()
        {
            // Arrange
            var educationId = 1;
            var request = new DeleteEducationRequest { Id = educationId };

            // Act
            var result = await _educationsController.Delete(request);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Update_Should_Return_OkResult()
        {
            // Arrange
            var request = new UpdateEducationRequest {};

            // Act
            var result = await _educationsController.Update(request);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task GetParticipants_Should_Return_OkResult_With_Valid_Education()
        {
            // Arrange
            var educationId = 1;
            var request = new GetEducationByIdRequest { Id = educationId };
            var education = new GetEducationByIdResponse {};

            // Mediator'den dönen cevap ayarlanıyor
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetEducationByIdRequest>(), default)).ReturnsAsync(education);

            // Act
            var result = await _educationsController.GetParticipants(request);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<GetEducationByIdResponse>(okObjectResult.Value);
            Assert.Equal(education, model);
        }

        [Fact]
        public async Task GetParticipant_Should_Return_OkResult_With_Valid_Participant()
        {
            // Arrange
            var educationId = 1;
            var participantName = "John Doe";
            var request = new GetEducationParticipantRequest { Id = educationId, Word = participantName };
            var participant = new GetEducationParticipantResponse {
            };

            // Mediator'den dönen cevap ayarlanıyor
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetEducationParticipantRequest>(), default)).ReturnsAsync(participant);

            // Act
            var result = await _educationsController.GetParticipant(educationId, participantName);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<GetEducationParticipantResponse>(okObjectResult.Value);
            Assert.Equal(participant, model);
        }
    }
}
