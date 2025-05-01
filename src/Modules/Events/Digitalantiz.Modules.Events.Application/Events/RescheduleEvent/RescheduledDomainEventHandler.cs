using Digitalantiz.Common.Application.Messaging;
using Digitalantiz.Modules.Events.Domain.Events;

namespace Digitalantiz.Modules.Events.Application.Events.RescheduleEvent;

internal sealed class RescheduledDomainEventHandler : IDomainEventHandler<EventRescheduledDomainEvent>
{
    public Task Handle(EventRescheduledDomainEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
