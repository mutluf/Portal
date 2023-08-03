using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Portal.Application.Features.Commands.Categories.CreateCategory;
using Portal.Application.Features.Commands.Categories.DeleteCategory;
using Portal.WebAPI.Controllers;

namespace PortalUnitTest.ControllersUnitTest
{
    public class CategoriesControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly CategoriesController _categoriesController;

        public CategoriesControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _categoriesController = new CategoriesController(_mediatorMock.Object);
        }

        [Fact]
        public async Task Create_Should_Return_OkResult()
        {
            // Arrange
            var request = new CreateCategoryRequest();

            // Act
            var result = await _categoriesController.Create(request);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Delete_Should_Return_OkResult()
        {
            // Arrange
            var categoryId = 1;
            var request = new DeleteCategoryRequest { Id = categoryId };

            // Act
            var result = await _categoriesController.Delete(request);

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}
