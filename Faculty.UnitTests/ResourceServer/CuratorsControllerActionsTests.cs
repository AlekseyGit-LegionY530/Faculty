using Moq;
using Xunit;
using System.Linq;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Faculty.Common.Dto.Curator;
using Faculty.BusinessLayer.Interfaces;
using Faculty.ResourceServer.Controllers;

namespace Faculty.UnitTests.ResourceServer
{
    public class CuratorsControllerActionsTests
    {
        private readonly Mock<ICuratorService> _mockCuratorService;

        public CuratorsControllerActionsTests()
        {
            _mockCuratorService = new Mock<ICuratorService>();
        }

        [Fact]
        public void IndexMethod_ReturnsOkObjectResult_WithListOfCuratorsDisplay_WhenListHaveValues()
        {
            // Arrange
            var curatorsDto = GetCuratorsDto();
            _mockCuratorService.Setup(x => x.GetAll()).Returns(curatorsDto);
            var curatorsController = new CuratorsController(_mockCuratorService.Object);

            // Act
            var result = curatorsController.GetCurators();

            // Assert
            var viewResult = Assert.IsType<OkObjectResult>(result.Result);
            var models = Assert.IsAssignableFrom<IEnumerable<CuratorDto>>(viewResult.Value);
            Assert.Equal(3, models.Count());
            curatorsDto.Should().BeEquivalentTo(models);
        }

        [Fact]
        public void IndexMethod_ReturnsNotFoundResult_WithListOfCuratorsDisplay_WhenListHaveNoValues()
        {
            // Arrange
            _mockCuratorService.Setup(x => x.GetAll()).Returns(It.IsAny<IEnumerable<CuratorDto>>());
            var curatorsController = new CuratorsController(_mockCuratorService.Object);

            // Act
            var result = curatorsController.GetCurators();

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        private static IEnumerable<CuratorDto> GetCuratorsDto()
        {
            var curatorsDto = new List<CuratorDto>()
            {
                new ()
                {
                    Id = 1,
                    Surname = "test1",
                    Name = "test1",
                    Doublename = "test1",
                    Phone = "+375-29-557-06-11"
                },
                new ()
                {
                    Id = 2,
                    Surname = "test2",
                    Name = "test2",
                    Doublename = "test2",
                    Phone = "+375-29-557-06-22"
                },
                new ()
                {
                    Id = 3,
                    Surname = "test3",
                    Name = "test3",
                    Doublename = "test3",
                    Phone = "+375-29-557-06-33"
                }
            };

            return curatorsDto;
        }

        [Fact]
        public void CreateMethod_ReturnsCreatedAtActionResult_WhenCorrectModel()
        {
            // Arrange
            const int idNewCurator = 1;
            var curatorDto = new CuratorDto
            {
                Id = idNewCurator,
                Surname = "test1",
                Name = "test1",
                Doublename = "test1",
                Phone = "+375-29-557-06-11",
            };
            _mockCuratorService.Setup(x => x.Create(It.IsAny<CuratorDto>())).Returns(curatorDto);
            var curatorsController = new CuratorsController(_mockCuratorService.Object);

            // Act
            var result = curatorsController.Create(curatorDto);

            // Assert
            Assert.IsType<CreatedAtActionResult>(result.Result);
        }

        [Fact]
        public void DeleteMethod_ReturnsNoContextResult_WhenModelWasFind()
        {
            // Arrange
            const int idExistCurator = 1;
            var curatorDto = new CuratorDto
            {
                Id = 1,
                Surname = "test1",
                Name = "test1",
                Doublename = "test1",
                Phone = "+375-29-557-06-11"
            };
            _mockCuratorService.Setup(x => x.GetById(idExistCurator)).Returns(curatorDto);
            _mockCuratorService.Setup(x => x.Delete(idExistCurator));
            var curatorsController = new CuratorsController(_mockCuratorService.Object);

            // Act
            var result = curatorsController.Delete(idExistCurator);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void DeleteMethod_ReturnsNotFoundResult_WhenModelWasNotFound()
        {
            // Arrange
            const int idExistCurator = 1;
            _mockCuratorService.Setup(x => x.GetById(idExistCurator)).Returns(It.IsAny<CuratorDto>());
            var curatorsController = new CuratorsController(_mockCuratorService.Object);

            // Act
            var result = curatorsController.Delete(idExistCurator);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void EditMethod_ReturnsNoContextResult_WhenModelIsCorrect()
        {
            // Arrange
            const int idExistCurator = 1;
            var curatorDto = new CuratorDto
            {
                Id = 1,
                Surname = "test1",
                Name = "test1",
                Doublename = "test1",
                Phone = "+375-29-557-06-11"
            };
            _mockCuratorService.Setup(x => x.GetById(idExistCurator)).Returns(curatorDto);
            _mockCuratorService.Setup(x => x.Edit(It.IsAny<CuratorDto>()));
            var curatorsController = new CuratorsController(_mockCuratorService.Object);

            // Act
            var result = curatorsController.Edit(curatorDto);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void EditMethod_ReturnsNotFoundResult_WhenModelWasNotFound()
        {
            // Arrange
            const int idExistCurator = 1;
            var curatorDto = new CuratorDto()
            {
                Id = 1,
                Surname = "test2",
                Name = "test2",
                Doublename = "test2",
                Phone = "+375-29-557-06-22"
            };
            _mockCuratorService.Setup(x => x.GetById(idExistCurator)).Returns(It.IsAny<CuratorDto>());
            var curatorsController = new CuratorsController(_mockCuratorService.Object);

            // Act
            var result = curatorsController.Edit(curatorDto);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}