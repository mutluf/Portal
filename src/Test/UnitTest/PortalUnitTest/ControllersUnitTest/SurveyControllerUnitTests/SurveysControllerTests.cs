using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Portal.API.Controllers;
using Portal.Application.DTOs.SurveyDTOs;
using Portal.Application.Features.SurveyFeatures.Commands.Surveys.CreateSurvey;
using Portal.Application.Features.SurveyFeatures.Commands.Surveys.DeleteSurvey;
using Portal.Application.Features.SurveyFeatures.Queries.Results;
using Portal.Application.Features.SurveyFeatures.Queries.Surveys.GetAllSurvey;
using Portal.Application.Features.SurveyFeatures.Queries.Surveys.GetSurveyById;

namespace PortalUnitTest.ControllersUnitTest.SurveyControllerUnitTests
{
    public class SurveysControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly SurveysController _surveysController;

        public SurveysControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _surveysController = new SurveysController(_mediatorMock.Object);
        }

        [Fact]
        public async Task Post_Should_Return_OkResult_With_Valid_Response()
        {
            // Arrange
            var request = new CreateSurveyRequest
            {
                Survey= new()
                {
                    Description="Description",
                    SolvedCount=1,
                    Title="Title",
                    UserId=1,
                    Questions= new List<QuestionDTO> { new QuestionDTO 
                    {  
                        QuestionContent="QuestionContent",
                        QuestionType="Multiple",
                        QuestionRate=10,
                        Options=new List<OptionDTO> {new OptionDTO 
                        { 
                            OptionContent="Content",
                            VoteAmount=10,} }
                        } 
                    }
                }
            };
            var response = new CreateSurveyResponse
            {
                Id=1,
            };

            _mediatorMock.Setup(m => m.Send(request, default)).ReturnsAsync(response);

            // Act
            var result = await _surveysController.Post(request);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<CreateSurveyResponse>(okObjectResult.Value);
            Assert.Equal(response, model);
        }

        [Fact]
        public async Task Get_Should_Return_OkResult_With_Valid_Surveys()
        {
            // Arrange
            var request = new GetAllSurveysRequest();
            var response = new GetAllSurveysResponse
            {
               
            };

            _mediatorMock.Setup(m => m.Send(request, default)).ReturnsAsync(response);

            // Act
            var result = await _surveysController.Get();

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<IList<SurveyDTO>>(okObjectResult.Value);
            Assert.Equal(response.SurveyDTOs, model);
        }

        [Fact]
        public async Task Get_By_Id_Should_Return_OkResult_With_Valid_Survey()
        {
            // Arrange
            var surveyId = 1;
            var request = new GetSurveyByIdRequest { Id = surveyId };
            var response = new GetSurveyByIdResponse
            {
            };

            _mediatorMock.Setup(m => m.Send(request, default)).ReturnsAsync(response);

            // Act
            var result = await _surveysController.Get(request);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<GetSurveyByIdResponse>(okObjectResult.Value);
            Assert.Equal(response, model);
        }

        [Fact]
        public async Task Delete_Should_Return_OkResult()
        {
            // Arrange
            var surveyId = 1;
            var request = new DeleteSurveyRequest { Id = surveyId };

            // Act
            var result = await _surveysController.Delete(request);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task GetResult_Should_Return_OkResult_With_Valid_Result()
        {
            // Arrange
            var resultId = 1;
            var request = new GetResultByIdRequest { Id = resultId };
            var response = new GetResultByIdResponse
            {
                Description="Desc",
                Title="Title",
                UserId=1,
                OptionVoteCount=1,
                ResponseCount=1,
                SolvedCount=1,
                Questions = new() { }
            };

            _mediatorMock.Setup(m => m.Send(request, default)).ReturnsAsync(response);

            // Act
            var result = await _surveysController.Get(request);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<GetResultByIdResponse>(okObjectResult.Value);
            Assert.Equal(response, model);
        }
    }
}
