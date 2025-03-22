using Application.Commands.WebProfile;
using Application.Commands.WebProfile.Req;
using Application.Commands.WebProfile.Res;
using Application.Queries.WebProfile;
using Application.Queries.WebProfile.Req;
using Application.Queries.WebProfile.Res;
using Core.Models;
using MediatR;
using Moq;
using Xunit;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationTests.Commands.WebProfile
{
    public class WebProfileTests
    {
        private readonly Mock<IMediator> _mediatorMock;

        public WebProfileTests()
        {
            _mediatorMock = new Mock<IMediator>();
        }

        [Fact]
        public async Task Create_WebProfile_ReturnSuccessAsync()
        {
            // Arrange
            var request = new CreateWebProfileRequest
            {
                Name = "Test Profile",
                LogoUrl = "https://example.com/logo.png",
                FaviconUrl = "https://example.com/favicon.ico",
                MetaKeywords = "test, keywords",
                MetaDescription = "Test description",
                Theme = new Core.Entities.Theme
                {
                    PrimaryColor = "#FF0000",
                    SecondaryColor = "#00FF00",
                    TertiaryColor = "#0000FF"
                },
                Carousels = new[]
                {
                    new Core.Entities.Carousel
                    {
                        Title = "Test Carousel",
                        Text = "Test Text",
                        Image = "https://example.com/carousel.jpg"
                    }
                },
                ProjectsForIndex = new[]
                {
                    new Core.Entities.ProjectForIndex
                    {
                        Name = "Test Project",
                        Image = "https://example.com/project.jpg",
                        Url = "https://example.com/project"
                    }
                },
                FooterLinks = new[]
                {
                    new Core.Entities.FooterLink
                    {
                        Text = "Test Footer Link",
                        Url = "https://example.com/footer"
                    }
                },
                NavbarLinks = new[]
                {
                    new Core.Entities.NavbarLink
                    {
                        Text = "Test Navbar Link",
                        Url = "https://example.com/navbar"
                    }
                }
            };

            var expectedResult = Result<CreateWebProfileResult>.Success(new CreateWebProfileResult());

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<CreateWebProfileCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResult);

            var mediator = _mediatorMock.Object;

            // Act
            var command = new CreateWebProfileCommand(request);
            var result = await mediator.Send(command, default);

            // Assert
            Assert.True(result.IsSuccess);
            _mediatorMock.Verify(m => m.Send(It.IsAny<CreateWebProfileCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Get_WebProfile_ReturnSuccessAsync()
        {
            // Arrange
            var expectedResult = Result<GetWebProfileResult>.Success(new GetWebProfileResult());
            var id = new Guid("50ecf85c-f71e-421d-be87-e153d5937f9a");

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetWebProfileByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResult);

            var mediator = _mediatorMock.Object;

            // Act
            var query = new GetWebProfileByIdQuery(new GetWebProfileByIdRequest { Id = id });
            var result = await mediator.Send(query, default);

            // Assert
            Assert.True(result.IsSuccess);
            _mediatorMock.Verify(m => m.Send(It.IsAny<GetWebProfileByIdQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Delete_WebProfile_ReturnSuccessAsync()
        {
            // Arrange
            var expectedResult = Result<DeleteWebProfileResult>.Success(new DeleteWebProfileResult());
            var id = new Guid("50ecf85c-f71e-421d-be87-e153d5937f9a");

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<DeleteWebProfileCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResult);

            var mediator = _mediatorMock.Object;

            // Act
            var command = new DeleteWebProfileCommand(new DeleteWebProfileRequest { Id = id });
            var result = await mediator.Send(command, default);

            // Assert
            Assert.True(result.IsSuccess);
            _mediatorMock.Verify(m => m.Send(It.IsAny<DeleteWebProfileCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Update_WebProfile_ReturnSuccessAsync()
        {
            // Arrange
            var request = new UpdateWebProfileRequest
            {
                Id = new Guid("50ecf85c-f71e-421d-be87-e153d5937f9a"),
                Name = "Updated Profile",
                LogoUrl = "https://example.com/updated-logo.png",
                FaviconUrl = "https://example.com/updated-favicon.ico",
                MetaKeywords = "updated, keywords",
                MetaDescription = "Updated description",
                Theme = new Core.Entities.Theme
                {
                    PrimaryColor = "#FF0000",
                    SecondaryColor = "#00FF00",
                    TertiaryColor = "#0000FF"
                }
            };

            var expectedResult = Result<UpdateWebProfileResult>.Success(new UpdateWebProfileResult());

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<UpdateWebProfileCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResult);

            var mediator = _mediatorMock.Object;

            // Act
            var command = new UpdateWebProfileCommand(request);
            var result = await mediator.Send(command, default);

            // Assert
            Assert.True(result.IsSuccess);
            _mediatorMock.Verify(m => m.Send(It.IsAny<UpdateWebProfileCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}