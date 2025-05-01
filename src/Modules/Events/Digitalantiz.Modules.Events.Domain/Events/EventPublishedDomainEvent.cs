using Digitalantiz.Common.Domain;

namespace Digitalantiz.Modules.Events.Domain.Events;

public class EventPublishedDomainEvent(Guid eventId) : DomainEvent
{
    public Guid EventId { get; init; } = eventId;
}
