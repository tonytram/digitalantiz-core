﻿using Digitalantiz.Common.Domain;

namespace Digitalantiz.Modules.Ticketing.Domain.Tickets;

public sealed class TicketCreatedDomainEvent(Guid ticketId) : DomainEvent
{
    public Guid TicketId { get; init; } = ticketId;
}
