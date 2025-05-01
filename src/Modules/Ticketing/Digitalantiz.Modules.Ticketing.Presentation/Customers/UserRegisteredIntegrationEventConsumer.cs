using Digitalantiz.Common.Application.Exceptions;
using Digitalantiz.Common.Domain;
using Digitalantiz.Modules.Ticketing.Application.Customers.CreateCustomer;
using Digitalantiz.Modules.Users.IntegrationEvents;
using MassTransit;
using MediatR;

namespace Digitalantiz.Modules.Ticketing.Presentation.Customers;

public sealed class UserRegisteredIntegrationEventConsumer(ISender sender)
    : IConsumer<UserRegisteredIntegrationEvent>
{
    public async Task Consume(ConsumeContext<UserRegisteredIntegrationEvent> context)
    {
        Result result = await sender.Send(
            new CreateCustomerCommand(
                context.Message.UserId,
                context.Message.Email,
                context.Message.FirstName,
                context.Message.LastName));

        if (result.IsFailure)
        {
            throw new DigitalantizException(nameof(CreateCustomerCommand), result.Error);
        }
    }
}
