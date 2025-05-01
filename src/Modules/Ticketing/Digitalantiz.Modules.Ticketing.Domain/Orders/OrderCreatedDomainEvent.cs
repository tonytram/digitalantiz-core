using Digitalantiz.Common.Domain;

namespace Digitalantiz.Modules.Ticketing.Domain.Orders;

public sealed class OrderCreatedDomainEvent(Guid orderId) : DomainEvent
{
    public Guid OrderId { get; init; } = orderId;
}
