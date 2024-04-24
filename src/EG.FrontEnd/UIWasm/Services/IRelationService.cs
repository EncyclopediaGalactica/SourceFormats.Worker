using EncyclopediaGalactica.BusinessLogic.Contracts;

namespace UIWasm.Services;

public interface IRelationService
{
    Task<ICollection<RelationResult>> GetAllAsync();
}
