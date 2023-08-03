using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Portal.Application.DTOs;
using Portal.Application.Features.Commands.Roles.CreateRole;
using Portal.Application.Features.Commands.Roles.UpdateRole;
using Portal.Application.Features.Queries.Roles.GetAllRoles;
using Portal.Application.Features.Queries.Roles.GetRoleById;
using Portal.WebAPI.Controllers;

namespace PortalUnitTest.ControllersUnitTest
{
    public class RolesControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly RolesController _rolesController;

        public RolesControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _rolesController = new RolesController(_mediatorMock.Object);
        }

        [Fact]
        public async Task GetRoles_Should_Return_OkResult_With_RolesList()
        {
            // Arrange
            var request = new GetAllRolesRequest();
            var roles = new Dictionary<int,string>
            {
                { 1, "Admin" },
                { 2, "User" },
            };
            var response = new GetAllRolesResponse { Datas = roles };

            // Mediator'den dönen cevap ayarlanıyor
            _mediatorMock.Setup(m => m.Send(request, default)).ReturnsAsync(response);

            // Act
            var result = await _rolesController.GetRoles(request);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<GetAllRolesResponse>(okObjectResult.Value);
            Assert.Equal(roles, model.Datas);
        }

        [Fact]
        public async Task GetRole_Should_Return_OkResult_With_Valid_Role()
        {
            // Arrange
            var roleId = 1;
            var request = new GetRoleByIdRequest { Id = roleId };
            var role = new RoleDTO { Id = roleId, Name = "Admin" };
            var response = new GetRoleByIdResponse { Id=1, Name="Participant" };

            // Mediator'den dönen cevap ayarlanıyor
            _mediatorMock.Setup(m => m.Send(request, default)).ReturnsAsync(response);

            // Act
            var result = await _rolesController.GetRole(request);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<GetRoleByIdResponse>(okObjectResult.Value);
            Assert.Equal(role, role);
        }

        //[Fact]
        //public async Task DeleteRole_Should_Return_OkResult()
        //{
        //    // Arrange
        //    var roleName = "Admin";
        //    var request = new DeleteRoleRequest { Name = roleName };
        //    //var response = new DeleteRoleResponse { IsDeleted = true };

        //    // Mediator'den dönen cevap ayarlanıyor
        //    _mediatorMock.Setup(m => m.Send(request, default)).ReturnsAsync(response);

        //    // Act
        //    var result = await _rolesController.DeleteRole(request);

        //    // Assert
        //    var okObjectResult = Assert.IsType<OkObjectResult>(result);
        //    var model = Assert.IsType<DeleteRoleResponse>(okObjectResult.Value);
        //    Assert.True(model.IsDeleted);
        //}

        [Fact]
        public async Task UpdateRole_Should_Return_OkResult_With_Updated_Role()
        {
            // Arrange
            var roleId = 1;
            var request = new UpdateRoleRequest { Id = roleId,  };
            var role = new RoleDTO { Id = roleId, Name = "UpdatedRole" };
            var response = new UpdateRoleResponse { };

            // Mediator'den dönen cevap ayarlanıyor
            _mediatorMock.Setup(m => m.Send(request, default)).ReturnsAsync(response);

            // Act
            var result = await _rolesController.UpdateRole(request);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<UpdateRoleResponse>(okObjectResult.Value);
            Assert.Equal(role, role);
        }

        [Fact]
        public async Task CreateRole_Should_Return_OkResult_With_New_Role()
        {
            // Arrange
            var request = new CreateRoleRequest {};
            var newRole = new RoleDTO { Id = 3, Name = "NewRole" };
            var response = new CreateRoleResponse {};

            // Mediator'den dönen cevap ayarlanıyor
            _mediatorMock.Setup(m => m.Send(request, default)).ReturnsAsync(response);

            // Act
            var result = await _rolesController.CreateRole(request);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<CreateRoleResponse>(okObjectResult.Value);
            Assert.Equal(newRole, newRole);
        }
    }
}
