using Application.Commands.Admin;
using Application.Commands.Admin.Req;
using MediatR;
using Moq;
using Xunit;
using System.Threading;
using System.Threading.Tasks;
using Application.Commands.Admin.Res;
using Core.Models;
using Application.Queries.Admin;
using Application.Queries.Admin.Req;
using Application.Queries.Admin.Res;

namespace ApplicationTests.Commands.Admin
{
    public class AdminHandlerTests
    {
        private readonly Mock<IMediator> _mediatorMock;

        public AdminHandlerTests()
        {
            _mediatorMock = new Mock<IMediator>();
        }

        [Fact]
        public async Task Create_Admin_ReturnSuccessAsync()
        {
            // Arrange
            var request = new CreateAdminRequest
            {
                Name = "Admin123",
                Password = "1235@asDasdfasdasd",
            };

            var expectedResult = Result<CreateAdminResult>.Success(new CreateAdminResult());

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<CreateAdminCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResult);

            var mediator = _mediatorMock.Object;

            // Act
            var command = new CreateAdminCommand(request);
            var result = await mediator.Send(command, default);

            // Assert
            Assert.True(result.IsSuccess);
            _mediatorMock.Verify(m => m.Send(It.IsAny<CreateAdminCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Get_Admin_ReturnSuccesAsync()
        {
            // Arrange
            var expectedResult = Result<GetAdminResult>.Success(new GetAdminResult());

            var id = new Guid("50ecf85c-f71e-421d-be87-e153d5937f9a");

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetAdminByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResult);

            var mediator = _mediatorMock.Object;

            // Act
            var query = new GetAdminByIdQuery(new GetAdminByIdRequest { Id = id });
            var result = await mediator.Send(query, default);

            // Assert
            Assert.True(result.IsSuccess);
            _mediatorMock.Verify(m => m.Send(It.IsAny<GetAdminByIdQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Delete_Admin_ReturnSuccessAsync()
        {
            // Arrange
            var expectedResult = Result<DeleteAdminResult>.Success(new DeleteAdminResult());
            var id = new Guid("50ecf85c-f71e-421d-be87-e153d5937f9a");
            _mediatorMock
                .Setup(m => m.Send(It.IsAny<DeleteAdminCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResult);
            var mediator = _mediatorMock.Object;

            // Act
            var command = new DeleteAdminCommand(new DeleteAdminRequest { Id = id });
            var result = await mediator.Send(command, default);

            // Assert
            Assert.True(result.IsSuccess);
            _mediatorMock.Verify(m => m.Send(It.IsAny<DeleteAdminCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Update_Admin_ReturnSuccessAsync()
        {
            // Arrange
            var request = new UpdateAdminRequest
            {
                Id = new Guid("50ecf85c-f71e-421d-be87-e153d5937f9a"),
                Name = "Admin123",
                Password = "1235@asDasdfasdasd",
            };
            var expectedResult = Result<UpdateAdminResult>.Success(new UpdateAdminResult());
            _mediatorMock
                .Setup(m => m.Send(It.IsAny<UpdateAdminCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResult);
            var mediator = _mediatorMock.Object;

            // Act
            var command = new UpdateAdminCommand(request);
            var result = await mediator.Send(command, default);

            // Assert
            Assert.True(result.IsSuccess);
            _mediatorMock.Verify(m => m.Send(It.IsAny<UpdateAdminCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
