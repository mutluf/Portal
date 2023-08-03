using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Portal.Application.DTOs;
using Portal.Application.Features.Commands.Workshops.CreateWorkshop;
using Portal.Application.Features.Commands.Workshops.DeleteWorkshop;
using Portal.Application.Features.Queries.Workshops.GetWorkshopById;
using Portal.Application.Features.Queries.Workshops.GetWorkshopParticipants;
using Portal.Domain.Entities;
using Portal.WebAPI.Controllers;

namespace PortalUnitTest.ControllersUnitTest
{
    public class WorkshopsControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly WorkshopsController _workshopsController;

        public WorkshopsControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _workshopsController = new WorkshopsController(_mediatorMock.Object);
        }

        [Fact]
        public async Task Create_Should_Return_OkResult()
        {
            // Arrange
            var request = new CreateWorkshopRequest
            {
                Title = "Test",
                IsCanceled = false,
                IsPublic = false,
                UserProfileId= 1,
                StartTime = DateTime.UtcNow,
                Description = "description",
            };

            // Act
            var result = await _workshopsController.Create(request);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Get_Should_Return_OkResult_With_Valid_Workshop()
        {
            // Arrange
            var workshopId = 1;
            var request = new GetWorkshopByIdRequest { Id = workshopId };
            var workshop = new GetWorkshopByIdResponse
            {
                Workshop = new()
                {                 
                    Id=1,
                    Title = "Test",
                    IsCanceled = false,
                    IsPublic = false,
                    UserProfileId = 1,
                    StartTime = DateTime.UtcNow,
                    Description = "description",
                    Participants = null
                }
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<GetWorkshopByIdRequest>(), default)).ReturnsAsync(workshop);

            // Act
            var result = await _workshopsController.Get(request);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<GetWorkshopByIdResponse>(okObjectResult.Value);
            Assert.Equal(workshop, model);
        }

        [Fact]
        public async Task Delete_Should_Return_OkResult()
        {
            // Arrange
            var workshopId = 1;
            var request = new DeleteWorkshopRequest { Id = workshopId };

            // Act
            var result = await _workshopsController.Delete(request);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task GetParticipants_Should_Return_OkResult_With_Valid_Participants()
        {
            // Arrange
            var workshopId = 1;
            var request = new GetWorkshopParticipantsRequest { Id = workshopId };
            var participants = new GetWorkshopParticipantsResponse {
                Participants = null
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<GetWorkshopParticipantsRequest>(), default)).ReturnsAsync(participants);

            // Act
            var result = await _workshopsController.GetParticipants(request);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<GetWorkshopParticipantsResponse>(okObjectResult.Value);
            Assert.Equal(participants, model);
        }
    }
}
