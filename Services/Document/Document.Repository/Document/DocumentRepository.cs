namespace EncyclopediaGalactica.Services.Document.SourceFormatsRepository.Document;

using Ctx;
using Entities;
using FluentValidation;
using Interfaces;
using Microsoft.EntityFrameworkCore;

/// <inheritdoc />
public partial class DocumentRepository : IDocumentsRepository
{
    private readonly DbContextOptions<DocumentDbContext> _dbContextOptions;
    private readonly IValidator<Document> _documentValidator;

    public DocumentRepository(
        DbContextOptions<DocumentDbContext> dbContextOptions,
        IValidator<Document> documentValidator)
    {
        ArgumentNullException.ThrowIfNull(dbContextOptions);
        ArgumentNullException.ThrowIfNull(documentValidator);

        _dbContextOptions = dbContextOptions;
        _documentValidator = documentValidator;
    }
}