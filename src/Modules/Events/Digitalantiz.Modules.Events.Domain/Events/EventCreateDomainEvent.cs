using Digitalantiz.Common.Domain;

namespace Digitalantiz.Modules.Events.Domain.Events;

public sealed class EventCreatedDomainEvent(Guid eventId) : DomainEvent
{
    public Guid EventId { get; init; } = eventId;
}
