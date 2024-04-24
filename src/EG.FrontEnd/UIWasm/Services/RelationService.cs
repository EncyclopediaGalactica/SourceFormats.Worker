using EncyclopediaGalactica.BusinessLogic.Contracts;

namespace UIWasm.Services;

public class RelationService : IRelationService
{
    private ICollection<RelationResult> _storage = new List<RelationResult>
    {
        new RelationResult
        {
            Id = 1,
            LeftDocument = new DocumentResult
            {
                Id = 1,
                Name = "Karman Todor Wikipedia page",
                Description = "Karman Todor Wikipedia page"
            },
            RightDocument = new DocumentResult
            {
                Id = 2,
                Name = "NeoVim Editor Wikipedia page",
                Description = "NeoVim Editor Wikipedia Page"
            }
        },
        new RelationResult
        {
            Id = 1,
            LeftDocument = new DocumentResult
            {
                Id = 1,
                Name = "Karman Todor Wikipedia page",
                Description = "Karman Todor Wikipedia page"
            },
            RightDocument = new DocumentResult
            {
                Id = 3,
                Name = "Jules Verne book from Gutenberg.org",
                Description = "Jules Verne book from Gutenberg.org"
            }
        },
    };

    public async Task<ICollection<RelationResult>> GetAllAsync()
    {
        return _storage;
    }
}
