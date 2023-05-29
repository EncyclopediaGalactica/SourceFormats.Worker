namespace EncyclopediaGalactica.Services.Document.SourceFormatsRepository.Unit.Tests.SourceFormatsService;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Ctx;
using Document;
using EncyclopediaGalactica.Utils.GuardsService;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Services.Document.SourceFormatsRepository.SourceFormatNode;
using ValidatorService;
using Xunit;

[ExcludeFromCodeCoverage]
[SuppressMessage("ReSharper", "InconsistentNaming")]
public class SourceFormatsService_Should
{
    public static IEnumerable<object[]> Throw_ArgumentNullException_WhenInjectedIsNull_Data = new List<object[]>
    {
        new[] { null, new DocumentRepository(
            new DbContextOptions<SourceFormatsDbContext>(),
            new DocumentValidator()) },
        new[]
        {
            new SourceFormatNodeRepository(
                new DbContextOptions<SourceFormatsDbContext>(),
                new SourceFormatNodeValidator(),
                new GuardsService()),
            null
        },
        new object[] { null, null }
    };

    [Theory]
    [MemberData(nameof(Throw_ArgumentNullException_WhenInjectedIsNull_Data))]
    public void Throw_ArgumentNullException_WhenInjectedIsNull(
        ISourceFormatNodeRepository sourceFormatNodeRepository,
        IDocumentsRepository documentsRepository)
    {
        // Assert
        Action a = () => { new SourceFormatsRepository(sourceFormatNodeRepository, documentsRepository); };
    }
}