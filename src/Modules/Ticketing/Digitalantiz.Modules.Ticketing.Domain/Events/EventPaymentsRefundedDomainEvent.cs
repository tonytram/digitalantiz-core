using Digitalantiz.Common.Domain;

namespace Digitalantiz.Modules.Ticketing.Domain.Events;

public sealed class EventPaymentsRefundedDomainEvent(Guid eventId) : DomainEvent
{
    public Guid EventId { get; init; } = eventId;
}
