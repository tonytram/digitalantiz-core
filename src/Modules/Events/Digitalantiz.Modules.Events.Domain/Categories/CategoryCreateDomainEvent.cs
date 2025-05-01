using Digitalantiz.Common.Domain;

namespace Digitalantiz.Modules.Events.Domain.Categories;

public sealed class CategoryCreateDomainEvent(Guid categoryId) : DomainEvent
{
    public Guid CategoryId { get; init; } = categoryId;
}
