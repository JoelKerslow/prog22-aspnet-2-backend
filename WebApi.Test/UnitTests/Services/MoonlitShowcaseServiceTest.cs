using Moq;
using WebApi.Helpers.Repositories;
using WebApi.Helpers.Services;
using WebApi.Models.Interfaces;
using WebApi.Test.Fixtures;

namespace WebApi.Test.UnitTests.Services;

public class MoonlitShowcaseServiceTest
{
    private Mock<IShowcaseRepository> _showcaseRepository;
    private IShowcaseService _showcaseService;

    public MoonlitShowcaseServiceTest()
    {
        _showcaseRepository = new Mock<IShowcaseRepository>();
        _showcaseService = new ShowcaseService(_showcaseRepository.Object);
    }

    [Fact]
    public async Task GetAllAsync_ReturnsAllShowcases()
    {
        //Arrange
        var showcases = ShowcaseFixture.Entities;
        _showcaseRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(showcases);

        //Act
        var result = await _showcaseService.GetAllAsync();

        //Assert
        Assert.Equal(showcases.Count, result.Count());
        _showcaseRepository.Verify(x => x.GetAllAsync(), Times.Once);
    }
}

