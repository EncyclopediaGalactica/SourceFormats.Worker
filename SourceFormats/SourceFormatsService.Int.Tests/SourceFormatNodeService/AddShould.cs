namespace EncyclopediaGalactica.SourceFormats.SourceFormatsService.Int.Tests.SourceFormatNodeService;

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Dtos;
using FluentAssertions;
using Sdk.Models.SourceFormatNode;
using Xunit;

[ExcludeFromCodeCoverage]
[Collection("SourceFormatServiceDatabaseOperationCollection")]
public class AddShould : BaseTest
{
    [Fact]
    public async Task Add_AnItem_AndReturnIt()
    {
        // Arrange
        string name = "asd";
        SourceFormatNodeDto dto = new()
        {
            Name = name
        };

        // Act
        SourceFormatNodeAddResponseModel result = await _sourceFormatsService
            .SourceFormatNode
            .AddAsync(dto).ConfigureAwait(false);

        // Assert
        result.Should().NotBeNull();
        result.Result.Should().NotBeNull();
        result.Result.Id.Should().NotBe(0);
        result.Result.Id.Should().BeGreaterThan(0);
        result.Result.Name.Should().Be(name);
    }
}