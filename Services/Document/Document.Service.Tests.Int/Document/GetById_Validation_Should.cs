namespace EncyclopediaGalactica.Services.Document.Service.Tests.Int.Document;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Base;
using FluentAssertions;
using Utils.GuardsService.Exceptions;
using Xunit;

[ExcludeFromCodeCoverage]
public class GetByIdValidationShould : BaseTest
{
    [Fact]
    public void ThrowGuardException_WhenInputIsInvalid()
    {
        // Arrange && Act
        Func<Task> f = async () => { await Sut.DocumentService.GetByIdAsync(0); };

        // Assert
        f.Should().ThrowExactlyAsync<GuardsServiceValueShouldNotBeEqualToException>();
    }
}