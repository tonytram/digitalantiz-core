namespace Digitalantiz.Common.Application.EventBus;

public abstract class IntegrationEvent(Guid id, DateTime occurredOnUtc) : IIntegrationEvent
{
    public Guid Id { get; set; } = id;

    public DateTime OccurredOnUtc { get; set; } = occurredOnUtc;
}
