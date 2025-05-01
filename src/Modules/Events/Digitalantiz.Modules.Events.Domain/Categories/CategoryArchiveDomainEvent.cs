using Digitalantiz.Common.Domain;

namespace Digitalantiz.Modules.Events.Domain.Categories;

public class CategoryArchiveDomainEvent(Guid categoryId) : DomainEvent
{
    public Guid CategoryId { get; init; } = categoryId;
}
