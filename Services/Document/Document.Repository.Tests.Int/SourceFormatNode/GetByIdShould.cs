namespace EncyclopediaGalactica.Services.Document.Repository.Tests.Int.SourceFormatNode;

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Base;
using Entities;
using FluentAssertions;
using Xunit;

[ExcludeFromCodeCoverage]
public class GetByIdShould : BaseTest
{
    [Fact]
    public async Task ReturnTheRightEntity()
    {
        // Arrange
        SourceFormatNode node1 = new SourceFormatNode();
        node1.Name = "asd";
        SourceFormatNode node1Result = await Sut.SourceFormatNodes.AddAsync(node1);

        SourceFormatNode node2 = new SourceFormatNode();
        node2.Name = "adfsdfsdfsdfs";
        SourceFormatNode node2Result = await Sut.SourceFormatNodes.AddAsync(node2);

        // Act
        SourceFormatNode result = await Sut.SourceFormatNodes.GetByIdAsync(node2Result.Id);

        // Assert
        result.Id.Should().Be(node2.Id);
        result.Name.Should().Be(node2.Name);
    }
}