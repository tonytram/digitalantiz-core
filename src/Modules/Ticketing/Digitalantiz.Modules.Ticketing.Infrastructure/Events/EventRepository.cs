﻿using Digitalantiz.Modules.Ticketing.Domain.Events;
using Digitalantiz.Modules.Ticketing.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Digitalantiz.Modules.Ticketing.Infrastructure.Events;

internal sealed class EventRepository(TicketingDbContext context) : IEventRepository
{
    public async Task<Event?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await context.Events.SingleOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public void Insert(Event @event)
    {
        context.Events.Add(@event);
    }
}
