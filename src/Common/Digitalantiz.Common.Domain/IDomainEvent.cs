using MediatR;

namespace Digitalantiz.Common.Domain;

public interface IDomainEvent : INotification
{
    Guid Id { get; }

    DateTime OccurredOnUtc { get; }
}
