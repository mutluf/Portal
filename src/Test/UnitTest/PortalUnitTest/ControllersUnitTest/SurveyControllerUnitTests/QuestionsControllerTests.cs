using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Portal.API.Controllers;
using Portal.Application.DTOs.SurveyDTOs;
using Portal.Application.Features.SurveyFeatures.Commands.Questions.CreateQuestion;
using Portal.Application.Features.SurveyFeatures.Commands.Questions.DeleteQuestion;
using Portal.Application.Features.SurveyFeatures.Queries.Questions.GetAllQuestions;

namespace PortalUnitTest.ControllersUnitTest.SurveyControllerUnitTests
{
    public class QuestionsControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly QuestionsController _questionsController;

        public QuestionsControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _questionsController = new QuestionsController(_mediatorMock.Object);
        }

        [Fact]
        public async Task Post_Should_Return_OkResult()
        {
            // Arrange
            var request = new CreateQuestionRequest
            {
                QuestionDTO = new QuestionDTO
                {
                    QuestionContent = "question",
                    QuestionRate = 10,
                    QuestionType = "Single",
                    Options = null
                }
            };

            // Act
            var result = await _questionsController.Post(request);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Get_Should_Return_OkResult_With_Valid_Questions()
        {
            // Arrange
            var request = new GetAllQuestionsRequest();
            var response = new GetAllQuestionsResponse
            {
                QuestionDTOs = new List<QuestionDTO>
                {
                    QuestionContent = "question",
                    QuestionRate = 10,
                    QuestionType = "Single",
                    Options = null
                }
            };

            _mediatorMock.Setup(m => m.Send(request, default)).ReturnsAsync(response);

            // Act
            var result = await _questionsController.Get();

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<List<QuestionDTO>>(okObjectResult.Value);
            Assert.Equal(response.QuestionDTOs, model);
        }

        [Fact]
        public async Task Delete_Should_Return_OkResult()
        {
            // Arrange
            var questionId = 1;
            var request = new DeleteQuestionRequest { Id = questionId };

            // Act
            var result = await _questionsController.Delete(request);

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}
