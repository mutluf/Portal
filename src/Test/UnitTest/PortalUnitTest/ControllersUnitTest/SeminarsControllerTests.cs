using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Portal.Application.Features.Commands.Seminars.CreateSeminar;
using Portal.Application.Features.Commands.Seminars.DeleteSeminar;
using Portal.Application.Features.Commands.Seminars.UpdateSeminar;
using Portal.Application.Features.Queries.Seminars.GetSeminarById;
using Portal.Application.Features.Queries.Seminars.GetSeminarParticipant;
using Portal.Application.Features.Queries.Seminars.GetSeminarParticipants;
using Portal.WebAPI.Controllers;

namespace PortalUnitTest.ControllersUnitTest
{
    public class SeminarsControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly SeminarsController _seminarsController;

        public SeminarsControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _seminarsController = new SeminarsController(_mediatorMock.Object);
        }

        [Fact]
        public async Task GetParticipant_Should_Return_OkResult_With_Valid_Participant()
        {
            // Arrange
            var seminarId = 1;
            var participantName = "Fatma Mutlu";
            var request = new GetSeminarParticipantRequest { Id = seminarId, Word = participantName };
            var participant = new GetSeminarParticipantResponse {  };

            _mediatorMock.Setup(m => m.Send(It.IsAny<GetSeminarParticipantRequest>(), default)).ReturnsAsync(participant);

            // Act
            var result = await _seminarsController.GetParticipant(seminarId, participantName);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<GetSeminarParticipantResponse>(okObjectResult.Value);
            Assert.Equal(participant, model);
        }

        [Fact]
        public async Task Create_Should_Return_OkResult()
        {
            // Arrange
            var request = new CreateSeminarRequest { /* gerekli alanları doldur */ };

            // Act
            var result = await _seminarsController.Create(request);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Get_Should_Return_OkResult_With_Valid_Seminar()
        {
            // Arrange
            var seminarId = 1;
            var request = new GetSeminarByIdRequest { Id = seminarId };
            var seminar = new GetSeminarByIdResponse {  };

            _mediatorMock.Setup(m => m.Send(It.IsAny<GetSeminarByIdRequest>(), default)).ReturnsAsync(seminar);

            // Act
            var result = await _seminarsController.Get(request);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<GetSeminarByIdResponse>(okObjectResult.Value);
            Assert.Equal(seminar, model);
        }

        [Fact]
        public async Task Delete_Should_Return_OkResult()
        {
            // Arrange
            var seminarId = 1;
            var request = new DeleteSeminarRequest { Id = seminarId };

            // Act
            var result = await _seminarsController.Delete(request);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Update_Should_Return_OkResult()
        {
            // Arrange
            var request = new UpdateSeminarRequest { };

            // Act
            var result = await _seminarsController.Update(request);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task GetParticipants_Should_Return_OkResult_With_Valid_Participants()
        {
            // Arrange
            var seminarId = 1;
            var request = new GetSeminarParticipantsRequest { Id = seminarId };
            var participants = new GetSeminarParticipantsResponse { };

            _mediatorMock.Setup(m => m.Send(It.IsAny<GetSeminarParticipantsRequest>(), default)).ReturnsAsync(participants);

            // Act
            var result = await _seminarsController.GetParticipants(request);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<GetSeminarParticipantsResponse>(okObjectResult.Value);
            Assert.Equal(participants, model);
        }
    }
}
