using Digitalantiz.Modules.Events.Domain.TicketTypes;
using Digitalantiz.Modules.Events.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Digitalantiz.Modules.Events.Infrastructure.TicketTypes;

internal sealed class TicketTypeRepository(EventsDbContext dbContext) : ITicketTypeRepository
{
    public async Task<TicketType?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await dbContext.TicketTypes.SingleOrDefaultAsync(t => t.Id == id, cancellationToken);
    }

    public async Task<bool> ExistsAsync(Guid eventId, CancellationToken cancellationToken = default)
    {
        return await dbContext.TicketTypes.AnyAsync(t => t.EventId == eventId, cancellationToken);
    }

    public void Insert(TicketType ticketType)
    {
        dbContext.TicketTypes.Add(ticketType);
    }
}
