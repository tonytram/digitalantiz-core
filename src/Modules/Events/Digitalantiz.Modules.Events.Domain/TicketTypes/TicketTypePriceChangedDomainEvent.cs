﻿using Digitalantiz.Common.Domain;

namespace Digitalantiz.Modules.Events.Domain.TicketTypes;

public sealed class TicketTypePriceChangedDomainEvent(Guid ticketTypeId, decimal price) : DomainEvent
{
    public Guid TicketTypeId { get; init; } = ticketTypeId;

    public decimal Price { get; init; } = price;
}
