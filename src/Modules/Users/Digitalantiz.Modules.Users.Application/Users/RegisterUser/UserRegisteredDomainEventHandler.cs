using Digitalantiz.Common.Application.EventBus;
using Digitalantiz.Common.Application.Exceptions;
using Digitalantiz.Common.Application.Messaging;
using Digitalantiz.Common.Domain;
using Digitalantiz.Modules.Users.Application.Users.GetUser;
using Digitalantiz.Modules.Users.Domain.Users;
using Digitalantiz.Modules.Users.IntegrationEvents;
using MediatR;

namespace Digitalantiz.Modules.Users.Application.Users.RegisterUser;

internal sealed class UserRegisteredDomainEventHandler(ISender sender, IEventBus eventBus)
    : IDomainEventHandler<UserRegisteredDomainEvent>
{
    public async Task Handle(UserRegisteredDomainEvent notification, CancellationToken cancellationToken)
    {
        Result<UserResponse> result = await sender.Send(new GetUserQuery(notification.UserId), cancellationToken);

        if (result.IsFailure)
        {
            throw new DigitalantizException(nameof(GetUserQuery), result.Error);
        }

        await eventBus.PublishAsync(
            new UserRegisteredIntegrationEvent(
                notification.Id,
                notification.OccurredOnUtc,
                result.Value.Id,
                result.Value.Email,
                result.Value.FirstName,
                result.Value.LastName), cancellationToken);
    }
}
