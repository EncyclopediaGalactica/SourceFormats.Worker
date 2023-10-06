namespace EncyclopediaGalactica.Services.Document.Service.Tests.Int.SourceFormatNodeService;

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Base;
using Dtos;
using FluentAssertions;
using Xunit;

[ExcludeFromCodeCoverage]
[Trait("Category", "DocumentService")]
public class GetAllShould : BaseTest
{
    [Fact]
    public async Task ReturnResponseModel_AllEntities_WhenThereAreEntitiesInTheDb()
    {
        // Arrange
        string name = "asdasd";
        SourceFormatNodeDto dto = new()
        {
            Name = name
        };

        await Sut.SourceFormatNode
            .AddAsync(dto);

        // Act
        List<SourceFormatNodeDto> result = await Sut.SourceFormatNode
            .GetAllAsync();

        // Assert
        result.Should().NotBeNull();
        result.Count.Should().BeGreaterThan(0);
        SourceFormatNodeDto elem = result.ElementAt(0);
        elem.Name.Should().Be(name);
    }

    [Fact]
    public async Task ReturnsResponseModel_EmptyList_WhenThereAreNoEntitiesInTheDb()
    {
        // Act
        List<SourceFormatNodeDto> result = await Sut.SourceFormatNode.GetAllAsync();

        // Assert
        result.Should().NotBeNull();
        result.Count.Should().Be(0);
    }
}