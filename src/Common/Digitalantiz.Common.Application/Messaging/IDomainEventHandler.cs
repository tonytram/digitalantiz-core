using Digitalantiz.Common.Domain;
using MediatR;

namespace Digitalantiz.Common.Application.Messaging;

public interface IDomainEventHandler<in TDomainEvent> : INotificationHandler<TDomainEvent>
    where TDomainEvent : IDomainEvent;
