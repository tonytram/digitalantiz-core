using Digitalantiz.Modules.Events.Domain.Events;
using Digitalantiz.Modules.Events.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Digitalantiz.Modules.Events.Infrastructure.Events;

internal sealed class EventRepository(EventsDbContext dbContext) : IEventRepository
{
    public async Task<Event?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await dbContext.Events.SingleOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public void Insert(Event @event)
    {
        dbContext.Events.Add(@event);
    }
}

