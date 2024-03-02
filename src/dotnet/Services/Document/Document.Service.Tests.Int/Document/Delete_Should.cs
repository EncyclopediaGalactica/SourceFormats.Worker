namespace EncyclopediaGalactica.Services.Document.Service.Tests.Int.Document;

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Base;
using Contracts.Output;
using FluentAssertions;
using Xunit;

[ExcludeFromCodeCoverage]
public class DeleteShould : BaseTest
{
    [Fact]
    public async Task DeleteEntity()
    {
        // Arrange
        List<long> recorded = await CreateDocumentDtoTestData(1);

        // Act
        await Sut.DocumentService.DeleteAsync(recorded[0]);
        List<DocumentResult> result = await Sut.DocumentService.GetAllAsync();

        // Assert
        result.Count.Should().Be(0);
    }
}