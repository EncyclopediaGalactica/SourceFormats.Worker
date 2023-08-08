namespace EncyclopediaGalactica.Services.Document.SourceFormatsService.Tests.Int.SourceFormatNodeService;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using FluentAssertions;
using Utils.GuardsService.Exceptions;
using Xunit;

[ExcludeFromCodeCoverage]
[Trait("Category", "DocumentService")]
public class GetByIdValidationShould : BaseTest
{
    [Fact]
    public async Task Throw_GuardsServiceValueShouldNotBeEqualToException_WhenIdIsZero()
    {
        // Act
        Func<Task> task = async () =>
        {
            await Sut.SourceFormatNode.GetByIdAsync(0)
                .ConfigureAwait(false);
        };

        // Assert
        await task.Should().ThrowExactlyAsync<GuardsServiceValueShouldNotBeEqualToException>();
    }
}