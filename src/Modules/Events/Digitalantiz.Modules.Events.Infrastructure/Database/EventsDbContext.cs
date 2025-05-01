using Digitalantiz.Modules.Events.Application.Abstractions.Data;
using Digitalantiz.Modules.Events.Domain.Categories;
using Digitalantiz.Modules.Events.Domain.Events;
using Digitalantiz.Modules.Events.Domain.TicketTypes;
using Microsoft.EntityFrameworkCore;

namespace Digitalantiz.Modules.Events.Infrastructure.Database;

public sealed class EventsDbContext(DbContextOptions<EventsDbContext> options) : DbContext(options), IUnitOfWork
{
    internal DbSet<Event> Events { get; set; }

    internal DbSet<Category> Categories { get; set; }

    internal DbSet<TicketType> TicketTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Events);
    }
}
