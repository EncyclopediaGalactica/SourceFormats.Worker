namespace EncyclopediaGalactica.DocumentDomain.Operations.Scenarios;

using Common.Scenario;

public class GetRelationSagaContext : ISagaContext
{
    public Guid CorrelationId { get; set; }
}