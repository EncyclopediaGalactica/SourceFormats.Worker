namespace EncyclopediaGalactica.Services.Document.SourceFormatsRepository.Tests.Int.SourceFormatNode;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using FluentAssertions;
using Utils.GuardsService.Exceptions;
using Xunit;

[ExcludeFromCodeCoverage]
[Trait("Category", "DocumentService")]
public class DeleteValidationShould : BaseTest
{
    [Theory]
    [InlineData(null)]
    [InlineData(0)]
    public async Task Throw_WhenInputIsInvalid(long id)
    {
        // Act
        Func<Task> action = async () => { await Sut.SourceFormatNodes.DeleteAsync(id).ConfigureAwait(false); };

        // Assert
        await action.Should()
            .ThrowExactlyAsync<GuardsServiceValueShouldNotBeEqualToException>()
            .ConfigureAwait(false);
    }
}