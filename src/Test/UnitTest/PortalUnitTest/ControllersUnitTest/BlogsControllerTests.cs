using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Portal.Application.Features.Commands.Blogs.CreateBlog;
using Portal.Application.Features.Commands.Blogs.DeleteBlog;
using Portal.Application.Features.Queries.Blogs.GetBlogById;
using Portal.WebAPI.Controllers;

namespace PortalUnitTest.ControllersUnitTest
{
    public class BlogsControllerTests
    {
        // Örnekler için sahte (Mock) IMediator
        private readonly Mock<IMediator> _mediatorMock;

        // BlogsController nesnesi
        private readonly BlogsController _blogsController;

        public BlogsControllerTests()
        {
            // Moq kullanarak sahte IMediator oluşturuluyor
            _mediatorMock = new Mock<IMediator>();

            // BlogsController'ı sahte IMediator ile oluştur
            _blogsController = new BlogsController(_mediatorMock.Object);
        }

        [Fact]
        public async Task CreateBlog_Should_Return_OkResult()
        {
            // Arrange
            var request = new CreateBlogRequest { /* gerekli alanları doldur */ };

            // Act
            var result = await _blogsController.CreateBlog(request);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Get_Should_Return_OkResult_With_Valid_Blog()
        {
            // Arrange
            var blogId = 1;
            var request = new GetBlogByIdRequest { Id = blogId };
            var blog = new GetBlogByIdResponse { /* sahte blog verisi oluştur */ };

            // Mediator'den dönen cevap ayarlanıyor
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetBlogByIdRequest>(), default)).ReturnsAsync(blog);

            // Act
            var result = await _blogsController.Get(request);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<GetBlogByIdResponse>(okObjectResult.Value);
            Assert.Equal(blog, model);
        }

        [Fact]
        public async Task Delete_Should_Return_OkResult()
        {
            // Arrange
            var blogId = 1;
            var request = new DeleteBlogRequest { Id = blogId };

            // Act
            var result = await _blogsController.Delete(request);

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}

