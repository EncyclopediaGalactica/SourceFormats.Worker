namespace EncyclopediaGalactica.Services.Document.ValidatorService;

using Entities;
using FluentValidation;

public class StructureValidator : AbstractValidator<StructureNode>
{
    public StructureValidator()
    {
        RuleSet(Operations.Add, () =>
        {
            RuleFor(p => p.Id)
                .Equal(0)
                .WithMessage("Id must be zero.");
        });
    }
}