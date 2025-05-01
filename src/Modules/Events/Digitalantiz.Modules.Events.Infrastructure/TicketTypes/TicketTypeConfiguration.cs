using Digitalantiz.Modules.Events.Domain.Events;
using Digitalantiz.Modules.Events.Domain.TicketTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Digitalantiz.Modules.Events.Infrastructure.TicketTypes;

internal sealed class TicketTypeConfiguration : IEntityTypeConfiguration<TicketType>
{
    public void Configure(EntityTypeBuilder<TicketType> builder)
    {
        builder.HasOne<Event>().WithMany().HasForeignKey(t => t.EventId);
    }
}
