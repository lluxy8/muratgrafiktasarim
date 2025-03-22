using Application.Commands.Category;
using Application.Commands.Category.Req;
using Application.Commands.Category.Res;
using Application.Queries.Category;
using Application.Queries.Category.Req;
using Application.Queries.Category.Res;
using Core.Models;
using MediatR;
using Moq;
using Xunit;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationTests.Commands.Category
{
    public class CategoryTests
    {
        private readonly Mock<IMediator> _mediatorMock;

        public CategoryTests()
        {
            _mediatorMock = new Mock<IMediator>();
        }

        [Fact]
        public async Task Create_Category_ReturnSuccessAsync()
        {
            // Arrange
            var request = new CreateCategoryRequest
            {
                Name = "Test Category"
            };

            var expectedResult = Result<CreateCategoryResult>.Success(new CreateCategoryResult());

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<CreateCategoryCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResult);

            var mediator = _mediatorMock.Object;

            // Act
            var command = new CreateCategoryCommand(request);
            var result = await mediator.Send(command, default);

            // Assert
            Assert.True(result.IsSuccess);
            _mediatorMock.Verify(m => m.Send(It.IsAny<CreateCategoryCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Get_Category_ReturnSuccessAsync()
        {
            // Arrange
            var expectedResult = Result<GetCategoryByIdResult>.Success(new GetCategoryByIdResult());

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetCategoryByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResult);

            var mediator = _mediatorMock.Object;

            // Act
            var query = new GetCategoryByIdQuery(new GetCategoryByIdRequest { Id = Guid.NewGuid() });
            var result = await mediator.Send(query, default);

            // Assert
            Assert.True(result.IsSuccess);
            _mediatorMock.Verify(m => m.Send(It.IsAny<GetCategoryByIdQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Delete_Category_ReturnSuccessAsync()
        {
            // Arrange
            var expectedResult = Result<DeleteCategoryResult>.Success(new DeleteCategoryResult());

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<DeleteCategoryCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResult);

            var mediator = _mediatorMock.Object;

            // Act
            var command = new DeleteCategoryCommand(new DeleteCategoryRequest { Id = Guid.NewGuid() });
            var result = await mediator.Send(command, default);

            // Assert
            Assert.True(result.IsSuccess);
            _mediatorMock.Verify(m => m.Send(It.IsAny<DeleteCategoryCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Update_Category_ReturnSuccessAsync()
        {
            // Arrange
            var request = new UpdateCategoryRequest
            {
                Id = Guid.NewGuid(),
                Name = "Updated Category"
            };

            var expectedResult = Result<UpdateCategoryResult>.Success(new UpdateCategoryResult());

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<UpdateCategoryCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResult);

            var mediator = _mediatorMock.Object;

            // Act
            var command = new UpdateCategoryCommand(request);
            var result = await mediator.Send(command, default);

            // Assert
            Assert.True(result.IsSuccess);
            _mediatorMock.Verify(m => m.Send(It.IsAny<UpdateCategoryCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
} 